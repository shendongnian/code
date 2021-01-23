    private async void RefreshOrLoadDataToCache()
    {
      if (IsNeededToCallAPI())
      {
        var taskForTimeEntries = LoadTimeEntriesTemp();
        DataTable dtTimeEntriesTemp = await taskForTimeEntries; // call await here
        DataTable dtEventsTemp = LoadEventsTemp();
        dtTimeEntriesTemp.Merge(dtEventsTemp);
      }
      else
        BindGridViews();
     }
