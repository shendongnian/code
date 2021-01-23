    // Defined somewhere which is available to you ForEach() and your Stop button.
    // In the stop button set the KeepProcessing to false.
    bool KeepProcessing = true;   
    foreach (string item in Processes)
    {
        if(!KeepProcessing)
             return;
        switch(.....
    }
