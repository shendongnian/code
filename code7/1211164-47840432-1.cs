    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string[] args = e.Args;
            if (SomeConditionBasedOnTheArgs(args))
            {
                // Instantiate view, call View.Show()
            }
            else
            {
                // Process the args
            }
        }
    }
