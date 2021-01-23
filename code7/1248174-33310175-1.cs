    public void Query()
    {
      List<QueryValue> QueriesList = quryValLister.GetQueriesList();
      List<ConnectionValues> ConnectionsList = concValLister.GetConnectionList();
      // iterating over servers 
      var tasks = ConnectionsList
          .Select(obj => Task.Run(() => new Controller(obj, QueriesList).FetchAll()))
          .ToArray();
      Task.WaitAll(tasks);
      foreach (var task in tasks)
        MyDataList.Add(task.Result);
    }
