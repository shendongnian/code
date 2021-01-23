    public DetailViewModel(INavigationService navigationService)
    {
        Task.Run(() =>
            {
                GetData();
            }).ContinueWith(
          (x) =>
          {
            Execute.OnUIThread(
                  () =>  DataList = new ObservableCollection<Data>(x.Result));
          });
        };
    }
    
    private Task<List<Data>> GetData()
    {
        using (var context = new MyDataContext())
        {
            return await (from data in context.Data
                                select data).ToListAsync();
           
        }
    }
