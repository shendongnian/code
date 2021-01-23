    private async void RefreshOrLoadDataToCache()
    {
      if (IsNeededToCallAPI())
      {
        var taskForTimeEntries = LoadTimeEntriesTemp();
        await Task.WhenAll(taskForTimeEntries); // calling await here
        DataTable dtTimeEntriesTemp = taskForTimeEntries.Result;
        DataTable dtEventsTemp = LoadEventsTemp();
        dtTimeEntriesTemp.Merge(dtEventsTemp);
      }
      else
        BindGridViews();
     }
