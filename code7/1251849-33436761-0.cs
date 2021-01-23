      foreach (DataRow dr in dt.Rows)
      {
           dynamic rowColl = new Object();
           foreach (DataColumn dc in dt.Columns)
           {
               rowColl.Add(dc.Caption, dr[dc].ToString());
           }
           rowColls.Add(rowColl);
       }
