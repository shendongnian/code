    //Getting all table cells for every column and row as string
    var tableValues = ds.Tables[0].AsEnumerable().SelectMany(i => i.ItemArray.ToString());
    Process[] lstprocess = Process.GetProcesses();
    
    var pro = from p in lstprocess
              where tableValues.Any(i => p.ProcessName.Contains(i))
              select p;
