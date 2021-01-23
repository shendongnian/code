    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "AcroRd32.exe";
    startInfo.Arguments = "/p " + YourPDFFilePath;
    process.StartInfo = startInfo;
    process.Start();
