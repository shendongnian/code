    //your method
    public void YourMethod()
    {
         Dictionary<int, int> result = new Dictionary<int, int>();
    
         int length = 0;
    
         if(dt1.Rows.Count > dt2.Rows.Count)
            length = dt1.Rows.Count
         else
             length = dt2.Rows.Count
    
         for(int i=0; i < length - 1; i++)
         {
             AddRowValue(dt1, result, i);
             AddRowValue(dt2, result, i);
         }  
    }
    
 
    public AddRowValue(DataTable tbl, Dictionary<int, int> dic, int index)
    {
        if( index > tbl.Rows.Count)
           return;
    
        DataRow row = tbl.Rows[index];
        
        int idValue = Convert.ToInt32(row["ID"]);
        int quantityValue = Convert.ToInt32(row["Quantity"]);
    
        if(dic.Keys.Contains(idValue)
             dic[idValue] = dic[idValue] + quantityValue;
        else
             dic.Add(idValue, quantityValue);
    }
