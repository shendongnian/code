    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Ping Application
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string filename = @"PingLog.csv";
    			{
    				using (var writer = new StreamWriter(filename, true)) 
    				{
    					writer.WriteLine("www.yahoo.com", Time in MilliSeconds);
    					try
    					{
    						Ping myPing = new Ping();
    						PingReply reply = myPing.Send("www.yahoo.com", 1000);
    						if (reply != null)
    						{
    							Console.WriteLine("{0}, {1}, {2}", reply.Address, reply.RoundtripTime, reply.RoundtripTime);
    						}
    					}					
    					catch
    					{
    						Console.WriteLine.("ERROR: You have some TIMEOUT issue");
    					}
    				}
    			}
    		}
    	}
    }
