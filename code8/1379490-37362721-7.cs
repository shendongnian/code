    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Hello_World
    {
        public class MainViewModel: INotifyPropertyChanged
        {
    
    
            private string _myLabel;
    
            public string MyLabel
            {
                get { return _myLabel; }
                set
                {
                    _myLabel = value;
                    OnPropertyChanged(nameof(MyLabel));
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
