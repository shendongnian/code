        private static void RunMage(string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "mage.exe",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            using (Process mage = Process.Start(startInfo))
            {
                while (!mage.StandardOutput.EndOfStream)
                {
                    Console.Out.WriteLine(mage.StandardOutput.ReadLine());
                }
                mage.WaitForExit();
            }
        }
