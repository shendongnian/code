    public class TestClass : INotifyPropertyChanged
    {
        string _name;
        
        public string Name
        {
            get { return _name;}
            set 
            {
                  _name = value;
                  _notifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
       
        private void _notifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
        public TestClass(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
    
