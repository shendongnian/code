    using System.ComponentModel;    
    public abstract class DiagramObject : INotifyPropertyChanged
    {
        //the actual variable
        private string _name;
        //how the variable is accessed and set
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        //
        public string AbbreviatedName
        {
            get
            {
                if (_name.Length>=1)
                {
                    return _name.Substring(0, 1);
                }
                else
                {
                    return "NA";
                }        
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
