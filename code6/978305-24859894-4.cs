    private int _modelNumber;
    public int ModelNumber
    {
        get { return SelectedModel.ModelNumber; }
        set
        {
            SelectedModel.ModelNumber = value;
            RaisePropertyChanged();
        }
    }
