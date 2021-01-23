    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Hello_World
    {
        public class ModelView: INotifyPropertyChanged
        {
    
    
            private string _myLabel;
    
            public string MyLabel
            {
                get { return _myLabel; }
                set
                {
                    _myLabel = value;
                    OnPropertyChanged("MyLabel");
                }
            }
    
    
    
    
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propetyName)
            {
                if(PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs(propetyName));
    
            }
    
        }
    }
