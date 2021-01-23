        private void Print(string pdfFileName)
        {
            string processFilename = Microsoft.Win32.Registry.LocalMachine
        .OpenSubKey("Software")
        .OpenSubKey("Microsoft")
        .OpenSubKey("Windows")
        .OpenSubKey("CurrentVersion")
        .OpenSubKey("App Paths")
        .OpenSubKey("AcroRd32.exe")
        .GetValue(string.Empty).ToString();
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = processFilename;
            info.Arguments = string.Format("/p /h {0}", pdfFileName);
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            ////(It won't be hidden anyway... thanks Adobe!)
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            int counter = 0;
            while (!p.HasExited)
            {
                System.Threading.Thread.Sleep(1000);
                counter += 1;
                if (counter == 5)
                {
                    break;
                }
            }
            if (!p.HasExited)
            {
                p.CloseMainWindow();
                p.Kill();
            }
        }
