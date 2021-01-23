     public class ContextAction : INotifyPropertyChanged
    {
        public string _name;   
        public ContextAction(string name)
        {
            _name = name;            
        }
        
        public string Name
        {
            get { return _name; }
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
}
