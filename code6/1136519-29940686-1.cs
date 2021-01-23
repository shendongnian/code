    public class LoginCommand : ICommand
    {
        private UserInfo info;
        private ICommand attachedCommand;
        public bool CanExecute(object parameter)
        {
            return parameter != null && info["FirstName"] == null && info["EMail"] == null;
        }
        public event EventHandler CanExecuteChanged = delegate { };
        public void Execute(object parameter)
        {
            Debug.WriteLine("This Works!");
            //Add execution logic here
            if (attachedCommand != null)
            {
                attachedCommand.Execute(parameter); //should close the window
            }
        }
        private void Info_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }
        public LoginCommand(UserInfo info)
        {
            this.info = info;
            info.PropertyChanged += Info_PropertyChanged;
        }
        public void AttachCommand(ICommand command) //attach the original command here
        {
            attachedCommand = command;
        }
    }
