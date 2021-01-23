    public Task<List<Data>> GetData(Guid ID)
    {
      Task<List<Data>> task = null;
      CachedDataObjects.TryGetValue(ID, out task);
      if (task == null)
      {
        if (ConnectedToServer)
        {
          task = Task.Run(() =>
          {
            try
            {
              //long data call
              return Service.GetKPI(ID);
            }
            catch (Exception e)
            {
              //deal with errors
            }
          });
        }
        DataObjects.Add(ID, task);
      }
      return task;
    }
