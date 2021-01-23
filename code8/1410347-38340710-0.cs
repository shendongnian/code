     public string SetFather
        {
            get { return _theFather; }
            set { 
                  if(!string.IsNullOrWhiteSpace(value)) 
                  { 
                     _theFather = value; 
                  }
                }
        }
