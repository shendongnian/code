    cmdPendingStatus.CommandType=CommandType.StoredProcedure;
    SqlDataReader pendingStatusList;
    List<string> lstPendingRequestId = new List<string>();
    try
    {
      conn.Open();
      pendingStatusList = cmdPendingStatus.ExecuteReader();
      if (pendingStatusList.HasRows)
      {
        while (pendingStatusList.Read())
        {
          if(condition here)
          {
            lstPendingRequestId.add("NEW VALUE")
          }
          else
          {
            lstPendingRequestId.Add(pendingStatusList.GetString(0));
          }
        }
      }
    }
