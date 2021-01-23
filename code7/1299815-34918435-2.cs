    [Serializable]
    class SpecializedModule : Module
    {
       public SpecializedModule()
       {
          mode = false;
       }
    
       private bool mode;
       public bool Mode
       {
          get
          {
             return this.mode;
          }
          set
          {
             if(this.mode != value)
             {
                this.mode = value;
                this.NotifyPropertyChanged("Mode");
             }
          }
       private bool modeEn;
       public bool ModeEn
       {
          get
          {
             return this.modeEn;
          }
          set
          {
             if(this.modeEn != value)
             {
                this.modeEn = value;
                this.NotifyPropertyChanged("ModeEn");
             }
          }
       }
    }
