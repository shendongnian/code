    public partial class AlphaNumericKeyboard : UserControl, INotifyPropertyChanged
    {
        private bool isUppercase;
        public bool IsUppercase
        {
            get { return isUppercase; }
            set
            {
                isUppercase = value; 
                NotifyPropertyChanged("IsUppercase");
            }
        }
        ...
        /// Implement INotifyPropertyChanged interface correctly
    }
