    var innerRows = new List<DataRow>();
    var outerRows = new List<DataRow>();
    
    foreach (DataRow rowAuthor in dsPubs.Tables["Consecuente"].Rows)
    {
       foreach (DataRow rowTitle in rowAuthor.GetChildRows(Oraciones1))
       {
          if (value == rowTitle["id_d"].ToString())
          {
             //remove all the child and the parent from the specified variable "value"   
             innerRows.Add(rowTitle);
             outerRows.Add(rowAuthor);
    
          }
    
       }
     }
    
    foreach(DataRow row in innerRows)
    {
       row.Delete();
    }
    
    foreach (DataRow row in outerRows)
    {
       row.Delete();
    }
