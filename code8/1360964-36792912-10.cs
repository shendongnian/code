    private static void SortOutputHandler(object sendingProcess, 
                DataReceivedEventArgs outLine)
     {
      // Collect the sort command output.
      if (!String.IsNullOrEmpty(outLine.Data))
       {
          timer = 0f; //Reset Process Timer
          numOutputLines++;
    
          // Add the text to the collected output.
          sortOutput.Append(Environment.NewLine + 
          "[" + numOutputLines.ToString() + "] - " + outLine.Data);
       }
     }
