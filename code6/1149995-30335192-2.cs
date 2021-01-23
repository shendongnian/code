    private int _cd_Raca;
    private string _nm_Raca;
    
    public int Cd_Raca
        {
            get{ return _cd_Raca;}
            set
            {
                if(_cd_Raca != value)
                {
                    _cd_Raca = value;
                        RaisePropertyChanged("Cd_Raca");
                }
            }
        }
    
        public string Nm_Raca
        {
            get{return _nm_Raca;}
            set
            {
                if(_nm_Raca != value)
                {
                    _nm_Raca = value;
                        RaisePropertyChanged("Nm_Raca");
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
