        var processes = Process.GetProcessesByName("notepad");
        if (processes.Length > 0)
        {
            var handle = processes[0].MainWindowHandle;
        }
        else
        {
            // Notepad is not started
        }  
 
