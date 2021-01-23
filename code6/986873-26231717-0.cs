    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo();    
    procStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
    proc.StartInfo = procStartInfo;
    proc.Start();
