    using System.Diagnostics;
    public static void Main(string[] args){
       Process[] arrProcesses = Process.GetProcesses();
       foreach (Process p in arrProcesses)
       {
           Console.WriteLine(p.MainWindowTitle);
       }
    }
