    public class Car
    {
        private ICommand _ClickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_ClickCommand == null)
                {
                    _ClickCommand = new RelayCommand(param => this.Click(param, EventArgs.Empty));
                }
                return _ClickCommand;
            }
        }
    }
