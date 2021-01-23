    using System;
    using System.Diagnostics;
    using System.Text;
    
    namespace uuidmac
    {
    	class MainClass
    	{
    		static string MacUUID ()
    		{
    			var startInfo = new ProcessStartInfo () {
    				FileName = "sh",
    				Arguments = "-c \"ioreg -rd1 -c IOPlatformExpertDevice | awk '/IOPlatformUUID/'\"",
    				UseShellExecute = false,
    				CreateNoWindow = true,
    				RedirectStandardOutput = true,
    				RedirectStandardError = true,
    				RedirectStandardInput = true,
    				UserName = Environment.UserName
    			};
    			var builder = new StringBuilder ();
    			using (Process process = Process.Start (startInfo)) {
    				process.WaitForExit ();
    				builder.Append (process.StandardOutput.ReadToEnd ());
    			}
    			return builder.ToString ();
    		}
    
    		public static int Main (string[] args)
    		{
    			Console.WriteLine (MacUUID ());
    			return 0;
    		}
    	}
    }
