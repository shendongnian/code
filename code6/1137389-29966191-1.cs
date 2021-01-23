    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            //Timer for speed guidance
            static Stopwatch stopwatch;
            //Data i use for generate time
            static List<int> timeData;
            static void Main(string[] args)
            {
                stopwatch = new Stopwatch();
                timeData = new List<int> { 1000, 800, 200, 700, 600, 300, 800, 100, 200, 300, 655, 856, 695, 425 };
                       
                ////-------------------------- SINGLE THREAD ------------------------------/////
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("             Single Threading Process            ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("   Process Time        Thread ID                 ");
                Console.WriteLine("-------------------------------------------------");
                stopwatch.Reset();
                stopwatch.Start();
                //For each normal that use only 1 thread
                foreach(int i in timeData)
                {
                    Process(i);
                }
              
                stopwatch.Stop();
                //Total time that the program take for making the process happen
                Console.WriteLine("*Total : " + stopwatch.Elapsed );
    
                ////-------------------------- Mulit Multiple ------------------------------/////
    
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("             Multi Threading Process            ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("   Process Time        Thread ID                 ");
                Console.WriteLine("-------------------------------------------------");
                stopwatch.Reset();
                stopwatch.Start();
                //for each thats use Multiple thread fr the process (can be made with parallel.invoke or Task Library or Thread Library)
                Parallel.ForEach(timeData, (i) => Process(i));
                //Total time that the program take for making the process happen
                Console.WriteLine("*Total : " + stopwatch.Elapsed);
                Console.WriteLine("-------------------------------------------------");
                Console.ReadKey();
            }
    
            // Methode for sumulating long processing
            static void Process( int time)
            {
                stopwatch.Reset();
                stopwatch.Start();
                //sleep time simulate the IO portion of the process
                Thread.Sleep(time);
                // The loop simulate de algoritme type of precessing
                for (int i = 0; i < time*1000000; i++){}
                stopwatch.Stop();
                Console.WriteLine( stopwatch.Elapsed + "         " + Thread.CurrentThread.ManagedThreadId.ToString());          
            }
    
    
        }
    }
