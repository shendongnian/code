    // Start the asynchronous read of the output stream.
    p.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
    p.EnableRaisingEvents = true;
    p.BeginOutputReadLine();
    p.Start();
    p.WaitForExit();
    p.Close();
    private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        // Collect the command output. 
        if (!String.IsNullOrEmpty(outLine.Data))
        {
            numOutputLines++;
            // Add the text to the output
            Console.WriteLine(Environment.NewLine + 
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);
        }
    }
