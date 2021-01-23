    using System.Diagnostics;
    namespace processexample {
    class Program {
        static void Main(string[] args) {
            ProcessStartInfo si = new ProcessStartInfo();
            si.CreateNoWindow = true;
            si.UseShellExecute = false;
            si.FileName = @"C:\Windows\System32\net.exe";
            si.Arguments = @"/help";
            Process p = new Process();
            p.StartInfo = si;
            p.Start();
            }
        }
    }
