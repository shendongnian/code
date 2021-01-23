    if (ds.Tables[0].Rows.Count > 0)
    {
      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
      {
        if(ds.Tables[0].Rows[i]["UserEmail"].ToString() == "10000")
        {
         //do something;
        }
      }
    }
