     public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }
        private string myString = string.Empty;
        public string MyString
        {
            get { return myString; }
            set { Set("MyString", ref myString, value); }
        }
        private string myOtherString;
        public string MyOtherString
        {
            get { return myOtherString; }
            set { Set("MyOtherString", ref myOtherString, value); }
        }
        private RelayCommand myCommand;
        public RelayCommand MyCommand
        {
            get
            {
                return myCommand ??
                    (myCommand = new RelayCommand(
                        () => MyOtherString = MyString,
                        () => MyString?.Length > 5));
            }
        }
    }
