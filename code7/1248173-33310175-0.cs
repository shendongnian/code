    public Task QueryAsync()
    {
      List<QueryValue> QueriesList = quryValLister.GetQueriesList();
      List<ConnectionValues> ConnectionsList = concValLister.GetConnectionList();
      // iterating over servers 
      var tasks = ConnectionsList
          .Select(obj => Task.Run(() => new Controller(obj, QueriesList).FetchAll()));
      MyDataList.AddRange(await Task.WhenAll(tasks));
    }
