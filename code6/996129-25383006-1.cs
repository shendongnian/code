        private static void TestMultipleCmdLaunches()
        {
            TestCmdLaunch("cmd.exe", GetNextColorCommand(), "title PCRF", "echo window 1", "sleep 60");
            TestCmdLaunch("cmd.exe", GetNextColorCommand(), "title PCRF", "echo window 2", "sleep 60");
            TestCmdLaunch("cmd.exe", GetNextColorCommand(), "title PCRF", "yes 1");
            TestCmdLaunch("cmd.exe", GetNextColorCommand(), "title PCRF", "yes 2");
        }
        static string[] backgroundColors = 
            { "0F","1F","2F","3F","4F", "5F", "60", "70", "8F", "90", "A0", "B0", "C0", "D0", "E0"};
        static int lastBackgroundColor = 0;
        private static string GetNextColorCommand()
        {
            int nextColor = unchecked(Interlocked.Increment(ref lastBackgroundColor) % backgroundColors.Length);
            return "color " + backgroundColors[nextColor];
        }
        private static void TestCmdLaunch(string filename, params string [] commands)
        {
            using (Process p = new Process())
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = filename;
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;
                p.StartInfo = info;
                p.Start();
                using (StreamWriter sw = p.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        foreach (var cmd in commands)
                        {
                            sw.WriteLine(cmd);
                        }
                    }
                }
            }
        }
