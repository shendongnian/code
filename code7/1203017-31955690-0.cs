    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        CreateDummyFile();
        Application.Run(new Form1());
        DeleteDummyFile();
    }
    
    static void CreateDummyFile() {
        String fileName = Directory.GetDirectories(Assembly.GetExecutingAssembly().CodeBase) + @"\" + Environment.MachineName + ".tmp";
        File.Create(fileName);
    }
    static void DeleteDummyFile() {
        String fileName = Directory.GetDirectories(Assembly.GetExecutingAssembly().CodeBase) + @"\" + Environment.MachineName + ".tmp";
        File.Delete(fileName);
    }
