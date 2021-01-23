    public class UserVM : INotifyPropertyChanged
    {
        private Visibility _textBoxVisibility;
        public Visibility TextBoxVisibility
        {
            get { return _textBoxVisibility; }
            set 
            {
                _textBoxVisibility = value;
                OnPropertyChanged();
            }
        }
        public string Fonction
        {
            get { return _fonction; }
            set
            {
                _fonction = value;
                OnPropertyChanged();
                if (value == "Value A")
                    TextBoxVisibility = Visibility.Hidden;
                else
                    TextBoxVisibility = Visibility.Visible;
            }
        }
        // Other members omitted for sake of simplicity.
    }
