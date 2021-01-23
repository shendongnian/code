    public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
    
                if (condition)
                {
                    var window = new MainWindow();
    
                    window.ShowDialog();
                }
                else
                {
                    AllocConsole();
                }
            }
    
            [DllImport("Kernel32.dll")]
            static extern void AllocConsole();
        }
