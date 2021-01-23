    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
        namespace nohub.process.exec
        {
        	class MainClass
        	{
        
        		[DllImport ("libc")]
        		private static extern int system (string exec);
        
        		private static string logfile = Path.GetTempFileName ();
        
        		static void Execute (string command, string commandPath, string arguments, bool nohup = false)
        		{
        			if (!nohup) {
        				var startInfo = new ProcessStartInfo () {
        					FileName = Path.Combine (commandPath, command),
        					Arguments = arguments,
        					UseShellExecute = false,
        					CreateNoWindow = true,
        					RedirectStandardOutput = true,
        					RedirectStandardError = true,
        					RedirectStandardInput = true,
        					UserName = System.Environment.UserName
        				};
        
        				using (Process process = Process.Start (startInfo)) { // Monitor for exit}
        					process.WaitForExit ();
        					using (var output = process.StandardOutput) {
        						Console.Write ("Results: {0}", output.ReadLine ());
        					}
        				}
        			} else {
        				system ("nohup " + Path.Combine (commandPath, command) + " " + arguments + " 2>&1 > " + logfile + " & "); 
        			}
        
        		}
        
        		public static void Main (string[] args)
        		{
        			Console.WriteLine ("Hello Stack Overflow");
        			Console.WriteLine ("Temp file: {0}", logfile);
        			Execute ("find", "", "/", true);
        			Thread.Sleep (1000);
        			Execute ("wc", "", "-l " + logfile, false);
        			Console.Write ("\nLet find continue? [y/n]");
        			if ((Console.ReadKey (false)).KeyChar == 'y')
        				system ("killall find");
        		}
        	}
        }
