    public static async Task Run(FileInfo executable, TextWriter writerForStandardOutput, TextWriter writerForStandardError)
    {
    	if (!executable.Exists)
    		throw new Exception("The given executable doesn't exist");
    
    	// Start the process
    	using (var process = new Process())
    	{
    		// Set up the process's start info
    		process.StartInfo = new ProcessStartInfo()
    		{
    			CreateNoWindow = true,
    			Domain = DOMAIN, // The domain needs to be specified or you'll get an error that says "The stub received bad data"
    			FileName = executable.FullName,
    			LoadUserProfile = true, // Set to true so that functionality isn't unnecessarily limited for the credentials this program will run under
    			Password = PASSWORD,
    			RedirectStandardError = true, // We'll be capturing errors
    			RedirectStandardOutput = true, // We'll be capturing output
    			UserName = USERNAME,
    			UseShellExecute = false, // Can't specify credentials to use unless this is set to false
    			WindowStyle = ProcessWindowStyle.Hidden
    		};
    		
    		// Create an object for synchronizing writes to the output and error TextWriter objects
    		var lockObject = new object();
    
    		// Set up listeners for when output or error data is received
    		process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
    		{
    			if (!ReferenceEquals(e.Data, null))
    			{
    				lock (lockObject)
    				{
    					writerForStandardOutput.WriteLine(e.Data);
    				}
    			}
    		});
    		process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
    		{
    			if (!ReferenceEquals(e.Data, null))
    			{
    				lock (lockObject)
    				{
    					writerForStandardError.WriteLine(e.Data);
    				}
    			}
    		});
    
    		// Try to start the executable
    		process.Start();
    		// Begin redirecting stdout and stderr
    		process.BeginOutputReadLine();
    		process.BeginErrorReadLine();
    
    		// Wait for the process to end
    		await Task.Run(() => { process.WaitForExit(); });
    	}
    }
