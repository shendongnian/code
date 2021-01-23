    public class MyViewModelClass: INotifyPropertyChanged
    {
        //Add Constructor
        public MyViewModelClass()
        {
            
        }
        private string nextSync = "N/A";
        public string NextSynchronization
        {
            get { return nextSync; }
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
