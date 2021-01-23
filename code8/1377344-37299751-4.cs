    public class MyViewModelClass: INotifyPropertyChanged
    {
        //Add Constructor
        public MyViewModelClass()
        {
            
        }
        private string _text = "sampleText shown in the TextBox";
        public string Text
        {
            get { return _text; }
            set 
            {
                nextSync = value;
                OnPropertyChanged();//PropertyName will be passed automatically
            }
        }
        private string _isChecked = true;//CheckBox is checked by default
        public string IsChecked
        {
            get { return _isChecked ; }
            set 
            {
                nextSync = value;
                OnPropertyChanged();//PropertyName will be passed automatically
            }
        }
        private string _btnText = "Click Me";//Text to display on the button
        public string BtnText
        {
            get { return _btnText ; }
            set 
            {
                nextSync = value;
                OnPropertyChanged();//PropertyName will be passed automatically
            }
        }
        
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        //When using the [CallerMemberName] Attribute you dont need to pass the PropertyName to the method which is pretty nice :D
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Implementation of INotifyPropertyChanged
    }
