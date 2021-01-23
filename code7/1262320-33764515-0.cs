    public bool concatenarArchivos(string archivos, string path, string destName)
        {
            bool returncode = false;
            try
            {
                string[] extensions = {".mp4"};
                string[] dirContents = System.IO.Directory.GetFiles(path, "*.*").Where(f => extensions.Contains(new FileInfo(f).Extension.ToLower())).ToArray();
                if (dirContents.Length > 0)
                {
                    string comando = string.Format("-f concat -i {0} -c copy {1}", archivos, string.Format("{0}\\{1}", path, destName));
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "ffmpeg.exe";
                    startInfo.WorkingDirectory = programPath;
                    startInfo.CreateNoWindow = true;
                    startInfo.Arguments = comando;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    //process.Close();
                    process.Dispose();
                    returncode = process.HasExited;
                }
            }
            catch (Exception ex)
            {
            }
            return returncode;
        }
