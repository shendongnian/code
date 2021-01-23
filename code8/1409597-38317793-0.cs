    private static void NetOutputDataHandler(object sendingProcess,
        DataReceivedEventArgs outLine)
    {
        // Collect the net view command output.
        if (!String.IsNullOrEmpty(outLine.Data))
        {
            // Add the text to the collected output.
            netOutput.Append(Environment.NewLine + "  " + outLine.Data);
            // And output it as it's sent
            Console.WriteLine(outLine.Data);
        }
    }
