    myProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
    {
    // Prepend line numbers to each line of the output.
    if (!String.IsNullOrEmpty(e.Data))
     {
        timer = 0f; //Reset Process Timer
        lineCount++;
        output.Append("\n[" + lineCount + "]: " + e.Data);
     }
    });
