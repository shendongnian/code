    public class ChatClient: INotifyPropertyChanged
    {
        //-------- Peopole property --------
        .
        .
        .
        //-------- ClientDoubleClickCommand --------
        ICommand clientDoubleClickCommand;
        public ICommand ClientDoubleClickCommand
        {
            get
            {
                return clientDoubleClickCommand ??
                    (clientDoubleClickCommand = new MyCommand(DoThisOnDoubleClick, true));
            }
        }
        private void DoThisOnDoubleClick(object clientId)
        {
            // Write your target codes (on Mouse Left Double Click) here:
            throw new NotImplementedException();
        }
        //-------- OTHER PROPERTIES AND CODES OF CLASS--------
        .
        .
        .
    }
    // MyCommand Class: This class is a technique to implement commands easily
    public class MyCommand: ICommand
    {
        private readonly Action<object> _action;
        private readonly bool _canExecute;
        public MyCommand(Action<object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
    public class People: INotifyPropertyChanged
    {
       // ClientId Property:
        .
        .
        .
       // ClientName Property:
        .
        .
        .
       //-------- OTHER PROPERTIES AND CODES OF CLASS--------
        .
        .
        .
    }
