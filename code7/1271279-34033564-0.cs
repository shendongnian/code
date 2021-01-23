    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    
    namespace ConsoleApplication1
    	{
    	class Program
    		{
    		static void Main(string[] args)
    			{
    			SelfContainedExampleTryCatch();
    			SelfContainedExampleContinueWith();
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
                }
    
    		public static void SelfContainedExampleTryCatch()
    			{
    			var errors = new List<Exception>();
    			try
    				{
    				ErrorAction();
    				}
    			catch (Exception ex)
    				{
    				errors.Add(ex);
    				}
    			errors.Count().Should().Be(1);
    			}
    
    		public static void SelfContainedExampleContinueWith()
    			{
    			var errors = new List<Exception>();
    			var task = Task.Factory.StartNew(ErrorAction);
    			task.ContinueWith(t =>
    			{
    				errors.Add(t.Exception);
    			}, TaskContinuationOptions.OnlyOnFaulted);
    			task.Wait();
    
    			errors.Count().Should().Be(1);
    			}
    
    		private static Action ErrorAction
    			{
    			get
    				{
    				return () => DoTask().Wait();
    				}
    			}
    
    		private static async Task DoTask() {
    			await Task.Delay(0);
    			throw new NotImplementedException();
    			}
    		}
    	}
