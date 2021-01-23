    var dtTemp = new DataTable();
    dtTemp.Columns.Add("i_pernr", typeof(int));
    dtTemp.Columns.Add("name", typeof(string));
    
    var dtData = new DataTable();
    dtData.Columns.Add("i_pernr", typeof(int));
    dtData.Columns.Add("name", typeof(string));
    dtData.PrimaryKey = new DataColumn[] { 
        dtData.Columns["i_pernr"], 
        dtData.Columns["name"]
        };
    
    var rnd = new Random();
    for(int r = 1; r<1000000; r++)
    {
        var row =dtData.NewRow();
        row[0] = rnd.Next(1000);
        row[1]= String.Format("the lazy fox jumps again {0}",rnd.Next(10000000)) ;
        try
        {
           dtData.Rows.Add(row);
        }
        catch
        {
           // Hey, for testing this is fine ...
        }
    }
