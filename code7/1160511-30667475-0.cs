        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                result+=e.Data;
            }
        });
        process.Start();
        // Asynchronously read the standard output of the spawned process.  
        // This raises OutputDataReceived events for each line of output.
        process.BeginOutputReadLine();
        process.WaitForExit();
        process.Close();
