	public void Main()
	{
		// TODO: Add your code here
        try
        {
			// variables used in process
			string l_sFolderCompressed = (string)Dts.Variables["User::sFolderCompressed"].Value;
			string l_sFolderSource = (string)Dts.Variables["User::sFolderSource"].Value;
			string l_sCommand = "zip -j " + l_sFolderCompressed + " " + l_sFolderSource + "/*";
            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/C " as the parameters.
            // Incidentally, /C tells cmd that we want it to execute the command that follows,
            // and then exit.
		    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + l_sCommand);		
            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            // Get the output into a string
            string result = proc.StandardOutput.ReadToEnd();
            // Possibly display the command output.
        }
        catch (Exception objException)
        {
            Dts.TaskResult = (int)ScriptResults.Failure;
            // Log the exception
        }
		Dts.TaskResult = (int)ScriptResults.Success;
	}
