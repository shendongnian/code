       private static void GetVideoDuration()
        {
            string basePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
            string filePath = basePath + @"1.mp4";
            string cmd = string.Format("-v error -select_streams v:0 -show_entries stream=duration -sexagesimal -of default=noprint_wrappers=1:nokey=1  {0}", filePath);
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(basePath, @"ffprobe.exe");
            proc.StartInfo.Arguments = cmd;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.UseShellExecute = false;
            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
                return;
            }
            string duration = proc.StandardOutput.ReadToEnd().Replace("\r\n", "");
            // Remove the milliseconds
            duration = duration.Substring(0, duration.LastIndexOf("."));
            proc.WaitForExit();
            proc.Close();
        }
