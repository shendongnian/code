         StringBuilder ZplBuilder = new StringBuilder();
        
        // Exemple ZPL String
        
                            ZplBuilder.Append("^XA");   //Start ZPL
                            ZplBuilder.Append("^FO320,42^APN,48,48^FD").Append(DateTime.Now.Date.ToString("dd/MM/yyyy")).Append("^FS");
    ZplBuilder.Append("^FO0,304^GB720,168,1^FS");
    ZplBuilder.Append("^FO0,306^GD720,166,1,B,L^FS");
    ZplBuilder.Append("^FO0,306^GD720,166,1,B,R^FS");
    ZplBuilder.Append("^XZ"); 
        // End ZPL
    
    string ZplString = ZplBuilder.ToString();
    
    MemoryStream lmemStream = new MemoryStream();
    
    StreamWriter lstreamWriter = new StreamWriter(lmemStream);
    lstreamWriter.Write(ZplString);
    lstreamWriter.Flush();
    lmemStream.Position = 0;
        
    byte[] byteArray = lmemStream.ToArray();
        
    IntPtr cpUnmanagedBytes = new IntPtr(0);
    int cnLength = byteArray.Length;
    cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
    Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);
        
    RawPrinterHelper.SendBytesToPrinter("Intermec PC43d (203 dpi)", cpUnmanagedBytes, cnLength);
    Marshal.FreeCoTaskMem(cpUnmanagedBytes);
