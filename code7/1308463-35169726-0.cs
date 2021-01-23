      try
                {
                    conn.Open();
                    pendingStatusList = cmdPendingStatus.ExecuteReader();
                    if (pendingStatusList.HasRows)
                    {
                        while (pendingStatusList.Read())
                        {
                            lstPendingRequestId.Add(pendingStatusList["ColumnName"]);
                        }
    
                    }
                }
