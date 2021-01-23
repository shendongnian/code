    public bool IsBusy{
        get{ return isBusy; }
        set{ 
           isBusy = value;
           FirePropertyChange();
        }
    }
