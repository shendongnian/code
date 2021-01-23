    class Program
    {
        static void Main(string[] args)
        {
            string procName = "ScreenScraper"; // Mind no ".exe" extension here
            foreach (var process in Process.GetProcessesByName(procName))
            {
                try
                {
                    var parent = myProcessEx.GetParentProcess(process.Id);
                    Console.WriteLine("{0} {1}; PARENT: {2} {3}",
                        process.Id, process.ProcessName, parent.Id, parent.ProcessName);
                }
                catch (ApplicationException exception)
                {
                    if (exception.InnerException is ArgumentException)
                    {
                        Console.WriteLine("An orphan '{0}' process found with PID {1}. Killing it...",
                            process.Id, process.ProcessName);
                        process.Kill();
                    }
                    else
                        throw;
                }
            }
        }
    }
