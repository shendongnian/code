        public void Print(string printerName, string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return;
            var url = fileName;
            var filePath = String.Format(@"{0}\{1}.pdf", Application.StartupPath, Guid.NewGuid().ToString());
            using (var client = new WebClient())
            {
                client.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                client.DownloadFile(url, filePath);
            }
            if (String.IsNullOrEmpty(Form1.SelectedPrinter))
                return;
            PrintDocument pdoc = new PrintDocument();
            pdoc.DefaultPageSettings.PrinterSettings.PrinterName = printerName;
            pdoc.DefaultPageSettings.Landscape = true;
            pdoc.DefaultPageSettings.PaperSize.Height = 140;
            pdoc.DefaultPageSettings.PaperSize.Width = 104;
            try
            {
                ProcessStartInfo gsProcessInfo;
                Process gsProcess;
                gsProcessInfo = new ProcessStartInfo();
                gsProcessInfo.Verb = "PrintTo";
                gsProcessInfo.CreateNoWindow = true; //The default is false.
                gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                gsProcessInfo.FileName = filePath;
                gsProcessInfo.Arguments = "\"" + printerName + "\"";
                gsProcess = Process.Start(gsProcessInfo);
                gsProcess.WaitForExit(4000);
                if (gsProcess.HasExited == false)
                {
                    gsProcess.Kill();
                }
                gsProcess.EnableRaisingEvents = true;
                gsProcess.Close();
            }
            catch (Exception)
            {
            }
        }
