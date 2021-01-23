    DataSet dsWinners = new DataSet();
    DataTable dataTable= ds.Tables[0].Clone();
    for(int i =0;i<=TotalWinners;i++)
      {
           for (int j = 1; j <= ds.Tables[0].Rows.Count; j++)
           {
              //this is my ds table 0
              left = Convert.ToInt16(ds.Tables[0].Rows[i]["ID"]);
              //this is my array 
              right = Convert.ToInt16(Winners[i, 0]);
              if ( left == right )//if array value matechs with ds.table[0] ID
              {
                //  dsWinners.Tables[0].Rows[i] = ds.Tables[0].Rows[j];
                  dataTable.Rows.Add( ds.Tables[0].Rows[j]);
               }
          }
      }
    dsWinners.Add(dataTable);
