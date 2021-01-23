        public class Item:InotifyPropertyChanged
        {
        private int id:
        public int Id
        {
        get{return id;}
        set
         {
          id=value;
          OnPropertyChanged(new PropertyChangedEventArgs("Id"));
         }
         }
        private string text;
        public string Text
        {
            get { return text; }
            set 
            {
                text = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
