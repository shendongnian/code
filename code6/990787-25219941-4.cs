    	public void InitializeProcess(object sender, EventArgs args)
    	{
            var processStartInfo = new ProcessStartInfo
            {
               UseShellExecute = false,
               ErrorDialog = false, 
               RedirectStandardError = true,
               RedirectStandardInput = true, 
               RedirectStandardOutput = true,
            }
            var myProcess = new Process(processStartInfo);
            myProcess.EnableRaisingEvents = true;
            myProcess.Exited += (s, e) => 
            { 
                // Do whatever you want when process ends, like 
                // Disposing of the streams.
            }
            _streamWriter = MyProcess.StandardInput;
    	    _streamReader = MyProcess.StandardOutput;
            myProcess.Start();
        }
