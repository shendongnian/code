    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    	class SMTHG
    	{
    		public void DoSomethingLikeSetValue(string input)
    		{
    			Console.WriteLine("HEYYYYY!!! DYNAMIC OBJECTS FTW!...\n" + input);
    		}
    	}
    	class Program
    	{
    		private static void QueueCheckNAdd<T>(ref T param, string input)
    		{
    			dynamic dynamicObject = (dynamic)param; 
    			dynamicObject.DoSomethingLikeSetValue(input);
    		}
    		static void Main(string[] args)
    		{
    			SMTHG smthg = new SMTHG();
    			QueueCheckNAdd(ref smthg, "yoyuyoyo");
    		}
    	}
    }
