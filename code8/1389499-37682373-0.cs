     [STAThread]
     static void Main()
     {
         NumberOfCores = getNumberOfCores();
         CPULoadVals = getCoreLoadVals();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MonitorGUI());
     }
