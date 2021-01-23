    class Model : INotifyPropertyChanged
    {
        private string textName;
        public string TextName
        {
            get { return textName; }
            set { 
                textName = value; 
                SignalPropertyChanged("TextName");
             }
        }
        private string rollNumber;
        public string RollNumber
        {
            get { return rollNumber; }
            set { 
                rollNumber= value; 
                SignalPropertyChanged("RollNumber");
             }
        }
        private string cclass;
        public string Class
        {
            get { return cclass; }
            set { 
                cclass= value; 
                SignalPropertyChanged("Class");
             }
        }
        public event PropertyChangedEventHandler propertyChanged;
        void SignalPropertyChanged(string propertyName){
            if(propertyChanged !=null){
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
