    private static void OutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!String.IsNullOrEmpty(outLine.Data))
        {  
            StdOutput.Append(Environment.NewLine + outLine.Data);
        }
    }
    private static void ErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!String.IsNullOrEmpty(outLine.Data))
        {  
            ErrOutput.Append(Environment.NewLine + outLine.Data);
        }
    }
