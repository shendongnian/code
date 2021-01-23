    foreach (DataColumn dc in r.ItemArray)
    {
       if (r[dc] != null) // This will check the null values also 
       {
           mb = mb + r[dc.ColumnName] + " ";  //Updated
       }
       MessageBox.Show(mb);
    }
