    public async void Update(object state)
    {
        var query = xbtceService.GetAllTicksAsync(); // get data from service
        query.Wait();
        var data = query.Result;
        if (data.Any())
        {
            dataAccess.SaveItems(data); //save data in database
        }
    
        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            Data.Clear();
            var list = dataAccess.LoadList();
            foreach (var item in list)
            {
                Data.Add(item);
            }
        });
    }
