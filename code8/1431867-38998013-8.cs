    public class LoginVM : INotifyPropertyChanged
    {
        private event EventHandler<string> _passwordSet;
        public event EventHandler<string> PasswordSet
        {
            add
            {
                _passwordSet += value;
                //  ...or else save latestServer in a private field, so here you can call 
                //  OnPasswordSet(_latestServer.Password) -- but since it's a password, 
                //  best not to keep it hanging around. 
                PopulateLatestServer();
            }
            remove { _passwordSet -= value; }
        }
