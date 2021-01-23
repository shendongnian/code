    public partial class App : System.Windows.Application
    {
        public bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses()) {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
    protected override void OnStartup(StartupEventArgs e)
    {
        // Get Reference to the current Process
        Process thisProc = Process.GetCurrentProcess();
        if (IsProcessOpen("name of application.exe") == false)
        {
            //System.Windows.MessageBox.Show("Application not open!");
            //System.Windows.Application.Current.Shutdown();
        }
        else
        {
            // Check how many total processes have the same name as the current one
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            {
                // If ther is more than one, than it is already running.
                System.Windows.MessageBox.Show("Application is already running.");
                System.Windows.Application.Current.Shutdown();
                return;
            }
            base.OnStartup(e);
        }
    }
