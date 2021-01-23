    foreach(Row row1 in Tables[0].Rows)
    {
       foreach(Row row2 in Tables[1].Rows)
       {
          If(row2["empID"] == row1["empID"])
          {
               row2.Delete();
          }
       }
    }
