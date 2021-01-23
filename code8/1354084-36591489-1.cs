    public class Book : INotifyPropertyChanged
    {
        private string title;
        public string Title {
           get { return title; }
           set {
               title = value;
               OnPropertyChanged("Title");
           }         
        }    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String info) 
        {
           if (PropertyChanged != null) {
               PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
