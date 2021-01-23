    public static string inputhistory1 = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Log\\" + Process.GetCurrentProcess().ProcessName + DateTime.Now.ToString("yyyyMMdd")+".chf";
    public static string inputhistory2 = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Log\\FileExtact" + DateTime.Now.AddMonths(-1).ToString("yyyyMM") + ".chf";
    public static string inputhistory3 = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Log\\FileExtact" + DateTime.Now.AddMonths(-2).ToString("yyyyMM") + ".chf";
    public static string inputhistory4 = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Log\\FileExtact" + DateTime.Now.AddMonths(-3).ToString("yyyyMM") + ".chf";
    List<string> inputHistories = new List<string>();
    inputHistories.Add(inputhistory1);
    inputHistories.Add(inputhistory2);
    inputHistories.Add(inputhistory3);
    inputHistories.Add(inputhistory4);
