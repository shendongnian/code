    class Program
    {
        private static readonly List<Process> AllProcesses = new List<Process>();
        static void Main(string[] args)
        {
            var timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += (sender, eventArgs) =>
            {
                Process[] processSnapShot = Process.GetProcesses();
                var newProcesses = processSnapShot.Where(p => !AllProcesses.Select(p2 => p2.Id).Contains(p.Id));
                WireHandler(newProcesses);
                AllProcesses.AddRange(newProcesses);
            };
            var processes = Process.GetProcesses();
            WireHandler(processes);
            timer.Start();
            Console.ReadLine();
        }
        private static void WireHandler(IEnumerable<Process> processes)
        {
            foreach (var process in processes)
            {
                try
                {
                    Console.WriteLine("Process started " + process.ProcessName);
                    process.EnableRaisingEvents = true;
                    process.Exited += ProcessOnExited;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occurred " + e.Message);
                }
            }
        }
        private static void ProcessOnExited(object sender, EventArgs eventArgs)
        {
            var process = (Process) sender;
            AllProcesses.Remove(process);
            Console.WriteLine("Process exited " + process.ProcessName);
        }
    }
