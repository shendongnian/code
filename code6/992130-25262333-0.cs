     Parallel.ForEach(Process.GetProcesses(),
                process =>
                {
                    foreach (ProcessModule m in process.Modules)
                    {
                        Console.WriteLine(m.FileName);
                    }
                });
