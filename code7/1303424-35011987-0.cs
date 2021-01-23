    public class ItemSetting : ViewModelBase
    {
        public string Description 
         get { return _description; } 
         set { _description = value; 
             this.RaisePropertyChanged("Description");
             }       
    }
