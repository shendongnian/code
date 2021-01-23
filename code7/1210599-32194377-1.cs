    private BindableCollection<MyDataClass> myData;
    public BindableCollection<MyDataClass> MyData
    {
        get { return myData; }
        set
        {
            myData= value;
            RaisePropertyChanged("MyData");
        }
    }
  
