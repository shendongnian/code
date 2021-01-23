    public class SomeClassViewModel
    {
        public SomeClassViewModel()
        {
            this.RefreshCmd = new RelayCommand(e => RefreshExec(), c => this.CanExecuteRefreshCmd());
        }
        public ICommand RefreshCmd { get; internal set; }
        private bool CanExecuteRefreshCmd()
        {
            return true;
        }
        public void RefreshExec()
        {
            // do something fancy here !
        }
    }
