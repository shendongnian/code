    private static void Main(string[] args)
    {
      ProcessContainer proc = new ProcessContainer();
      List<string> output = proc.RunProcessGrabOutput("ping.exe", "-n 5 8.8.8.8");
      if (output != null)
      {
        Console.WriteLine("Program's output:");
        foreach (string line in output)
          Console.Write(">> " + line);
      }
      else Console.WriteLine("Unable to start program.");
    } 
