using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AnonymousMethods
{
    class Program
    {
        //using normal delegate
        delegate int PointToAdd(int num1,int num2);

        //create a delegate for anonymous function
        delegate int PointToAddAnonymous(int num1,int num2);

        static void Main(string[] args)
        {
            
            Stopwatch watch = new Stopwatch();

            // compare performance between the two types anonymous and normal delegates
            //invoke both methods 10000 times and record the time every 1000 times

            Console.WriteLine("non Anonymous method");
            // first we test normal delegate
            for (int i = 0; i < 10; i++) 
            {
                watch.Reset();
                watch.Start();
                for (int j = 0; j < 1000; j++) 
                {
                    //create delegate
                    PointToAdd obj = Add;
                    //invoke delegate
                    int num = obj.Invoke(6, 4);
                }
                
                watch.Stop();
                
                Console.WriteLine("{0}",watch.ElapsedTicks.ToString());
            }
            Console.WriteLine("-------------------------");


            Console.WriteLine("Anonymous method");

            // now we test anonymous method
            
            for (int i = 0; i < 10; i++)
            {
                watch.Reset();
                watch.Start();
                for (int j = 0; j < 1000; j++)
                {
                    //anonymous example
                    PointToAddAnonymous objAnonymous = delegate(int num1, int num2)
                    {
                        return num1 + num2;
                    };
                    //invoke anonymous
                    int num = objAnonymous.Invoke(6, 4);
                }
                watch.Stop();

                Console.WriteLine("{0}", watch.ElapsedTicks.ToString());
            }
            Console.WriteLine("-------------------------");


            Console.ReadKey();
        }

        static int Add(int num1, int num2) 
        {
            return num1 + num2;
        }
    }
}
