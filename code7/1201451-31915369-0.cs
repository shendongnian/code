    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var spotify = new Process();
                spotify.StartInfo.FileName = "Spotify.exe";
                spotify.StartInfo.Arguments = "-v -s -a";
                Process.Start("powercfg", "-CHANGE -monitor-timeout-ac 0");
                spotify.Start();
                spotify.WaitForExit();
                var exitCode = spotify.ExitCode;
                spotify.Close();
                Process.Start("powercfg", "-CHANGE -monitor-timeout-ac 1");
            }
        }
    }
