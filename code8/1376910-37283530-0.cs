    public RelayCommand<int> MyCommand = new RelayCommand<int>((i) =>
    {
        if (i != 0)
        {
            DoSomething(i);
        }
    });
