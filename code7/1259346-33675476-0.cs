    using System;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                const int VK_RETURN = 0x0D;
                const int WM_KEYDOWN = 0x100;
                var cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                // Capture output
                cmd.OutputDataReceived += (sender, args) =>
                {
                    if (string.IsNullOrEmpty(args.Data) == false)
                    {
                        var x = args.Data;
                    }
                };
                cmd.Start();
                // Need to call this method in order to raise the OutputDataReceivedEvent for each line of output
                cmd.BeginOutputReadLine();
                using (var stdin = cmd.StandardInput)
                {
                    stdin.WriteLine("ftp");
                    stdin.WriteLine("open localhost");
                    stdin.WriteLine("anonymous");
                    var hWnd = Process.GetCurrentProcess().MainWindowHandle;
                    PostMessage(hWnd, WM_KEYDOWN, VK_RETURN, 0);
                    stdin.WriteLine("ls");
                    stdin.WriteLine("close localhost");
                    stdin.WriteLine("bye");
                }
                cmd.WaitForExit();
                cmd.Close();
            }
            private void PostMessage(IntPtr hWnd, int wmKeydown, int vkReturn, int i)
            {
                // No idea what you are doing here
            }
        }
    }
