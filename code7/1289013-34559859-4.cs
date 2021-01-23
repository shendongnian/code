    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace ConsoleApplication4
    {
    	internal class Program
    	{
    		private class BruteforceParams
    		{
    			public int StartNumber { get; set; }
    			public int EndNumber { get; set; }
    		}
    
    		private const int password = 14995399;
    		private static readonly Stopwatch time = new Stopwatch();
    
    		private static void Main(string[] args)
    		{
    			const int maxPassword = 100000000;
    
    			Console.WriteLine("Enter number of threads: ");
    			var threadsCountString = Console.ReadLine();
    			var threadsCount = int.Parse(threadsCountString);
    
    			var threads = new Thread[threadsCount];
    			for (int i = 0; i < threadsCount; i++)
    			{
    				var thread = new Thread(Bruteforce);
    				threads[i] = thread;
    			}
    
    			time.Start();
    			for (int i = 0; i < threadsCount; i++)
    			{
    				threads[i].Start(new BruteforceParams { StartNumber = i * maxPassword / threadsCount, EndNumber = (i + 1) * maxPassword / threadsCount });
    			}
    
    			Console.ReadKey();
    		}
    
    		private static void Bruteforce(object param)
    		{
    			var bp = (BruteforceParams) param;
    			for (int i = bp.StartNumber; i < bp.EndNumber; i++)
    			{
    				if (i == password)
    				{
    					Console.WriteLine("Şifre=" + i);
    					time.Stop();
    					Console.WriteLine("Time elapsed: {0}", time.Elapsed);
    				}
    			}
    		}
    	}
    }
