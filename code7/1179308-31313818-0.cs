     Foreach(DataRow row in yourDataTable.Rows)
     {
          if(dicData.ContainsKey(row["firstColumn"]))
          {
             dicData[row["firstColumn"].ToString()].Add(row["secondColumn"].ToString());
          }
          else
          {
             List<string> list = new List<string>();
             list.Add(row["secondColumn"].ToString())
             dicData.Add(row["firstColumn"].ToString(), list)
          }
     }
