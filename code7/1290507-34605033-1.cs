    public class serial : INotifyPropertyChanged
        {
            private string debuger_rec;
            public string Debugger_Recoreded
            {
                get { return debuger_rec; }
                set
                {
    
                    if (this.debuger_rec == value)
                        return;
    
                    this.debuger_rec = value;
                    i--;
                    if (i == 0)
                    {
                        this.debuger_rec = String.Empty;
    
                        i = 1000;
                    }
                    OnPropertyChanged("Debugger_Recoreded");   
    
               }    
     
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(name));
                    }
            }
            }
