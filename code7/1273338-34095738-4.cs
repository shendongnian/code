    public DataSet FlipDataSet(DataSet my_DataSet)
    {
     DataSet ds = new DataSet();
    
     foreach (DataTable dt in my_DataSet.Tables)
     {
       DataTable table = new DataTable();
    
       for (int i = 0; i <= dt.Rows.Count; i++)
       {   table.Columns.Add(Convert.ToString(i));  }
    
       DataRow r;
       for (int k = 0; k < dt.Columns.Count; k++)
       { 
         r = table.NewRow();
         r[0] = dt.Columns[k].ToString();
         for (int j = 1; j <= dt.Rows.Count; j++)
         {  r[j] = dt.Rows[j - 1][k]; }
         table.Rows.Add(r);
       }
       ds.Tables.Add(table);
     }
    
     return ds;
    }
