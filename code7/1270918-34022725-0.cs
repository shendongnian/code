    public void SoxMethod()
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "sox-14-4-2/sox.exe";
            startInfo.Arguments = "sox-14-4-2/input.wav -r 16000 output.wav";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;
            startInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            using (Process soxProc = Process.Start(startInfo))
            {
                soxProc.WaitForExit();
            }
        }
