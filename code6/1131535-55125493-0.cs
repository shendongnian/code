    <MasterTableView DataKeyNames="Response, ...
    
    foreach (GridDataItem item in FTReport.MasterTableView.Items)
    {
      string ResponseValue = tbResponse.Text;
      if (item.GetDataKeyValue("Response").ToString() != ResponseValue)
      {
        do something;
      }
    }
