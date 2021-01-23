            Process[] processes_array = Process.GetProcessesByName("someprogram");
            foreach (Process some_process in processes_array)
            {
                some_process.EnableRaisingEvents = true;
                some_process.Exited += delegate (object sender, EventArgs args)
                {
                    // Do work.
                    // DISPOSE PROCESS IF NOT USING IT AFTER THIS!!
                };
            }
