    public class MainViewModel : INotifyPropertyChanged
    {
        private string _messagebox_text = "";
        public string messagebox_text
        {
            get
            {
                return _messagebox_text;
            }
            set
            {
                _messagebox_text = value;
                NotifyPropertyChanged("messagebox_text");
            }
        }
    }
