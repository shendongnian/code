    public class ApplicationCommand : RelayCommand
    {
        private string logName;
        public ApplicationCommand(Action<T> execute, string logName = "")
        {
            // ...
            this.logName = logName;
        }
        public void Execute()
        {
            // No try-catch, I never code bugs ;o)
            Log.Info("Prepare to execute the command " + this.logName);
            base.Execute();
            Log.Info("Finished to execute the command " + this.logName);
        }
    }
