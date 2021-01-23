    public string SomeText
    {
        get { return MyModel.SomeText; }
        set
        {
            MyModel.SomeText = value;
            RaisePropertyChanged("SomeText");
        }
    }
