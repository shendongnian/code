    public class Person: INotifyPropertyChanged
    {
        private string name;
    
        private int age;
    
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }
    
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
                this.OnPropertyChanged("Age");
            }
        }
    
        protected void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
