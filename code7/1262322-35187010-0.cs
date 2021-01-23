    public bool convertAvitoMkv(string path, string sourceName, string destName)
        {
    
            bool returncode = false;
            try
            {
                string comando = string.Format("-i {0} -c:v libx264 -crf 19 -preset slow -c:a libfaac -b:a 192k -ac 2 {1}", string.Format("{0}\\{1}",path,sourceName), string.Format("{0}\\{1}",path,destName) + ".mkv");
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "ffmpeg.exe";
                startInfo.WorkingDirectory = programPath;
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = comando;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                process.StartInfo = startInfo;
                process.Start();
                StreamReader readerOut = process.StandardOutput;
                StreamReader readerErr = process.StandardError;
                // Process the readers e.g. like follows
                string errors = readerErr.ReadToEnd();
                string output = readerOut.ReadToEnd();
 
                while (!process.HasExited)
                {
                    continue; 
                }
    
                returncode = process.HasExited;
            }
            catch (Exception ex)
            {
    
            }
            return returncode;
        }
