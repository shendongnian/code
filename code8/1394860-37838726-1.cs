       public event PropertyChangedEventHandler PropertyChanged;
       protected void OnPropertyChanged(string name)
       {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null)
               {
                  handler(this, new PropertyChangedEventArgs(name));
               }
        }
        
        
        private Job currentJob;
        public Job CurrentJob
        {
              get{ return curentJob; }
              private set
              {
                  if( this.currentJob != value )
                  {
                     this.currentJob = value;
                     OnPropertyChanged("CurrentJob");
                  }
              }
         }
