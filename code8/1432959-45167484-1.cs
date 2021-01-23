    public class ViewModel : INotifyPropertyChanged
    {
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                if(PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
