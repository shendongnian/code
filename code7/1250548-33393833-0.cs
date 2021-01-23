    public bool IsItemSelected { get {return null != SelectedModelItem; }
    
    public YourModelType SelectedModelItem{
    get{
       return selectedModelItem;
    }
    set{
       selectedModelItem = value;
       OnPropertyChanged();   
       }
    }
