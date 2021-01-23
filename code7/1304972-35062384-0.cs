    class Program {
    	protected static /* yeah, yeah, it's only an example */ StringBuilder output;
    	static void Main(string[] args)
    	{
    		// Create the process
    		var process = new System.Diagnostics.Process();
    		process.EnableRaisingEvents = true;
    		process.StartInfo.UseShellExecute = false;
    		process.StartInfo.FileName = "php.exe";
    		process.StartInfo.Arguments = "-f path\\test.php mu b 0 0 pgsql://user:pass@x.x.x.x:5432/nominatim";
    		process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    		process.StartInfo.RedirectStandardOutput = true;
    	
    		output = new StringBuilder();
    		process.OutputDataReceived += process_OutputDataReceived;
    	
    		// Start the process
    		process.Start();
    		process.BeginOutputReadLine();
    	
    		// Wait for the process to finish
    		process.WaitForExit();
    	
    		Console.WriteLine("test");
            // <-- do something with Program.output here -->
    	
    		Console.ReadKey();
    	}
    	
    	static void process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
    	{
    		if (!String.IsNullOrEmpty(e.Data)) {
    			output.Append(e.Data);
    		}
    	}
    }
