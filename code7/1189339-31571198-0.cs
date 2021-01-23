    public class LoginDialogModel : BindableBase
    {
        private List<string> _connections;
    
        public List<string> Connections
        {
            get { return _connections; }
            set { SetProperty(ref _connections,value); }
        }
    }
