    private static void NetErrorDataHandler(object sendingProcess, 
        DataReceivedEventArgs errLine)
    {
        // Write the error text to the file if there is something
        // to write and an error file has been specified.
        if (!String.IsNullOrEmpty(errLine.Data))
        {
            if (!errorsWritten)
            {
                if (streamError == null)
                {
                    // Open the file.
                    try 
                    {
                        streamError = new StreamWriter(netErrorFile, true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not open error file!");
                        Console.WriteLine(e.Message.ToString());
                    }
                }
                if (streamError != null)
                {
                    // Write a header to the file if this is the first
                    // call to the error output handler.
                    streamError.WriteLine();
                    streamError.WriteLine(DateTime.Now.ToString());
                    streamError.WriteLine("Net View error output:");
                }
                errorsWritten = true;
            }
            if (streamError != null)
            {
                // Write redirected errors to the file.
                streamError.WriteLine(errLine.Data);
                streamError.Flush();
            }
        }
    }
