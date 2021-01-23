    using System.Runtime.InteropServices;
    ...
    namespace CSharpTests
    {
        public class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern int Wow64DisableWow64FsRedirection(ref IntPtr ptr);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern int Wow64EnableWow64FsRedirection(ref IntPtr ptr);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern int Wow64RevertWow64FsRedirection(ref IntPtr ptr);
            static void Main(string[] args)
            {
                IntPtr val = IntPtr.Zero;
                Wow64DisableWow64FsRedirection(ref val);
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c quser";
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                Console.WriteLine(output);
                Wow64RevertWow64FsRedirection(ref val);
                p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c quser";
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                Console.WriteLine(output);
            }
        }
    }
