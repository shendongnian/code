    Dictionary<int, string> myDic = new Dictionary<int, string>();
    
    for (int i = 0; i < table1.Rows.Count; i++)
    {
         if (myDic.ContainsKey(table1.Rows[i][0]))
         {
              myDic[table1.Rows[i][0]] += $", {table1.Rows[i][2]}";
         }
         else
         {
              myDic.Add(table1.Rows[i][0], table1.Rows[i][2]);
         }
    }
