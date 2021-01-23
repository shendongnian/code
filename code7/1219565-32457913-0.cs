     StringBuilder result = new StringBuilder();
     //write columns
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            result.Append(dt.Columns[i].ColumnName);
			if(i == dt.Columns.Count - 1)
			{
			result.Append("\n");
			}
			else
			{
			result.Append(",");
			}
            
        }
         //write rows		
        foreach (DataRow row in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                result.Append(row[i].ToString());
               if(i == dt.Columns.Count - 1)
			   {
			    result.Append("\n");
			   }
			   else
			   {
			   result.Append(",");
			   }
            }
        }
        //write result to a file		
       StreamWriter file = new StreamWriter(@"your file");
	   file.WriteLine(result.ToString());
