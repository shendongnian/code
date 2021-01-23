    string strAppDir = Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
    // or...
    // string strAppDir = AppDomain.CurrentDomain.BaseDirectory;
    string strFullPathToMyFile = System.IO.Path.Combine(strAppDir, "Stc.cts");
    StreamReader sr = new StreamReader(strFullPathToMyFile);
