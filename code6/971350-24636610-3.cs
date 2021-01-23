    // Start the asynchronous read of the sort output stream.
    p.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
    p.EnableRaisingEvents = true;
    p.BeginOutputReadLine();
    p.Start();
    p.WaitForExit();
    p.Close();
    private static void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        // Collect the sort command output. 
        if (!String.IsNullOrEmpty(outLine.Data))
        {
            numOutputLines++;
            // Add the text to the collected output.
            Console.WriteLine(Environment.NewLine + 
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);
        }
    }
