         int TotalRows = 0;
         for (int i = 0; i < table.Rows.Count; i++)
            {
                if(i == 0)
                {
                  TotalRows = 1;
                }
                 else
                 {
                   TotalRows + = i;  
                 }        
                string rowNum = table.Rows[i].ToString();
                table.Columns.Add("Book num", typeof(string), rowNum);
               }
