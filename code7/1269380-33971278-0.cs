    using System;
    using System.Diagnostics;
    class Program
    {
      static int count = 0;
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
        count++;  //add a lock statement here to avoid any race conditions
        if (count == 3)
            Console.WriteLine("Finised");
      }
    }
