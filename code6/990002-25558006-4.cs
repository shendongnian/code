    da.Fill(ds);
       for (int i = 0; i < ds.Tables.Count; i++)
       {
    	   if (i == 0)
    		   da.TableMappings.Add("table", GetTableName(i, ds));
    	   else
    		   da.TableMappings.Add("table" + i.ToString(), GetTableName(i, ds));
    	
       }
