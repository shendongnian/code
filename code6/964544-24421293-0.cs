    var procInfo = new ProcessStartInfo("notepad");
            procInfo.Arguments = "foo.txt";
            var proc = new Process();
            proc.StartInfo = procInfo;
            proc.Start(); //Actually executes the process
            proc.WaitForExit(); //Waits until the process completes, in this case, when you close notepad
