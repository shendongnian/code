       public class Commands : ICommand
        {
            private bool canExecute = true;
    
            public bool CanExecute(object parameter)
            {
                return canExecute;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public void Execute(object parameter)
            {
                NotifyCanExecute(false);
                var information = parameter.ToString();
                try
                {
                    if (information == "Show Passed") Events.ShowAllPassedTests(this, new EventArgs());
                    if (information == "Show Failed") Events.ShowAllFailedTests(this, new EventArgs());
                    if (information == "Sort By elapsed Time") Events.SortByElapsedTime(this, new EventArgs());
                    if (information == "Sort By Run Data") Events.SortByRunData(this, new EventArgs());
                    if (information == "Sort By Title") Events.SortByTitle(this, new EventArgs());
                    if (information == "Generate HTML Report") Events.GenerateHTMLReport(this, new EventArgs());
                }
                catch (NullReferenceException nre) {
                    Trace.WriteLine("Test Runner Commands 320- An attempt to fire an event failed due to no subscribers");
                }
                NotifyCanExecute(true);
            }
    
            private void NotifyCanExecute(bool p)
            {
                canExecute = p;
                if (CanExecuteChanged != null) CanExecuteChanged(this, new EventArgs());
            }
        }
