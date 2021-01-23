    public bool MasterIsChecked
    {
        get { return masterIsChecked; }
        set 
        {
            masterIsChecked = value; 
            NotifyPropertyChanged("MasterIsChecked");
            foreach (YourClass item in YourItems) item.IsChecked = masterIsChecked;
        }
    }
