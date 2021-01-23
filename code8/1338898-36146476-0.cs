    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace Test
    {
    	class Program
    	{
    		static void Main()
    		{
    			{
    				//I NEED TO COMPARE THIS TIME WITH THE LAST LOGGED TIME
    				DateTime x = DateTime.Now;
    				DateTime time = x; //File.GetLastWriteTimeUtc(watcher.Path + "\\vimrc");
    				DateTime newTimeFormat = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
    				time.ToString("O");
    
    				string log = x.ToString();
    				{
    
    					Console.WriteLine(Convert.ToDateTime(log).ToString("s"));
    					var result = Convert.ToDateTime(Convert.ToDateTime(log).ToString("s"));
    
    					//THIS ERRORS EVERY SINGLE TIME, EVEN WHEN LOG IS CONVERTED TO A 100% VERIFIABLE LEGITIMATE FORMAT
    					if (result < time)
    					{
    						Console.WriteLine("bleh why don't my conversions work!?!??!!?");
    					}
    				}
    			}
    
    		}
    	}
    }
