        public static void OpenFile(string path, bool isDirectory = false)
        {
            if (string.IsNullOrEmpty(path)) return;
            if ((isDirectory && Directory.Exists(path)) || (!isDirectory && File.Exists(path)))
            {
                ProcessStartInfo pi = new ProcessStartInfo(path);
                pi.Arguments = Path.GetFileName(path);
                pi.UseShellExecute = true;
                pi.WindowStyle = ProcessWindowStyle.Normal;
                pi.Verb = "OPEN";
                Process proc = new Process();
                proc.StartInfo = pi;
                proc.Start();
            }
        } 
