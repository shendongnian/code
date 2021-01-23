    using System;
    using System.Diagnostics;
    class Program
    {
      static int count = 0;
      static object obj = new object();
      static void Main(string[] args)
      {
        Process[] Processes = new Process[3];
        for (int i = 0; i < 3; i++)
        {
            Processes[i] = Process.Start("notepad.exe");
            Processes[i].EnableRaisingEvents = true;
            Processes[i].Exited += Program_Exited;
        }
        Console.ReadLine();
      }
      private static void Program_Exited(object sender, System.EventArgs e)
      {
        lock (obj)
        {
            count++;
        }
        if (count == 3)
            Console.WriteLine("Finised");
      }
    }
