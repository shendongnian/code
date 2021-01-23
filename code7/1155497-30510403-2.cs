    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process
            {
                StartInfo = {FileName = "notepad.exe"}
            };
            p.Start();
            
            p.Dispose();
            // Notepad still runs...
            GC.Collect(); // Just for the diagnostics....
            // Notepad still runs...
            Console.ReadKey();
        }
    }
