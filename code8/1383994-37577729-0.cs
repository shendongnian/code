    public class BrowseCommand : ICommand
    {
        public virtual void Execute(object parameter)
        {
            var path = parameter as string;
            if (String.IsNullOrWhiteSpace(path) == false)
            {
                // if path is URL, start browser with selected page
                Process.Start(new ProcessStartInfo(path));
            }
        }
        public virtual bool CanExecute(object parameter)
        {
            var path = parameter as string;
            return !String.IsNullOrWhiteSpace(path);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
