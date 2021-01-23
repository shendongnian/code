    if (!Directory.Exists(destination))
    {
        log.WriteLine(DateTime.Now + " Error: destination directory not found for: " + args[1] );
        log.WriteLine(DateTime.Now + " ******************************************** SPLITTER ENDED ****************************************************************");
        // write all pending log messages to the file
        log.Flush();
        System.Environment.Exit(0);
    }
