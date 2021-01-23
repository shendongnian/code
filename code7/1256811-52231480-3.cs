    using System.ComponentModel;
    
    public class SomeModelName : INotifyPropertyChanged
    {
        
        private string text;
        
        public string Text
        {
            set
            {
                if (text != value)
                {
                    text = value;
                    RaisePropertyChanged("Text");
                }
            }
        }
        
        // some other properties and methods might go here
        ...
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }
