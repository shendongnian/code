    private static void Main(string[] args)
    {
        var procs = Process.GetProcesses();
        foreach ( var proc in procs )
        {
            Console.WriteLine(proc.Id);
        }
    }
