    public class MyViewModel
    {
        private ICommand _myCommand;
        public ICommand MyCommand
        {
            get
            {
                if (_myCommand== null)
                {
                    _myCommand = new RelayCommand(
                        p => this.CanMyCommandExecute(),
                        p => this.MyCommandExecute()
                }
                return _myCommand;
            }
        }
    }
