            foreach (Process p in Process.GetProcesses())
            {
                string name = p.ProcessName.ToLower();
                if (name == "flawlesswidescreen") p.Kill();
            }
