    public DetailViewModel(INavigationService navigationService)
        {
            Task.Run(() =>
                {
                    GetData();
                });
        }
    
    private void GetData()
    {
        using (var context = new MyDataContext())
        {
            var result = await (from data in context.Data
                              select data).ToListAsync();
            DataList = new ObservableCollection<Data>(result);
        }
    }
