    public class Item : INotifyPropertyChanged
    {
        private string prop2;
        public string Prop2 
        { 
             get { return prop2; }
             set { prop2 =  value; OnPropertyChanged("Prop2"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var eh = this.PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
