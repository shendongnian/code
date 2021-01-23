            Process[] proc = Process.GetProcessesByName("Java");
            if (proc.Count() != 0)
            {
                //Process Alive
                Process prod = proc[0];
                prod.Kill();
                prod.WaitForExit();
            }
            else
            {
                //Process Dead
            }
