    Dictionary<string, id> usersByCode;//Init + fill it in
    for (int i= 0; i< HugeDataTable.Rows.Count; i++)
    {
      tempIp= int.Parse(HugeDataTable.Rows[i]["col1"].ToString());
      if(usersByCode.Contains(tempId) 
      {
        //Do something
      }
    }
