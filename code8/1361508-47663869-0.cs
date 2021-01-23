        public void Print(int numCopies = 1)
        {
            int randomInt = (new Random()).Next(1000); //this random value is intented to get the collision change of prn file names reduced 
            string SERVERPATH = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/PrintOperations/"));
            if (!Directory.Exists(SERVERPATH))
            {
                Directory.CreateDirectory(SERVERPATH);
            }
            String prnFilePath = SERVERPATH + MethodName + randomInt + ".prn";
            String fullPrinterPath = @"\\"+ServerName+@"\"+ printerName;
            var createdFile = System.IO.File.Create(prnFilePath);
            createdFile.Close();
            System.IO.File.WriteAllText(prnFilePath, parsedZpl);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = string.Format("/C Copy \"{0}\" \"{1}\"", prnFilePath ,fullPrinterPath);
            process.StartInfo = startInfo;
            for (int i =0; i< numCopies; i++)
            {
                process.Start();
                process.WaitForExit();
            }
            System.IO.File.Delete(prnFilePath);
    }
