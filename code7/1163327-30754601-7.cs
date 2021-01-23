    var pTable = Marshal.AllocHGlobal(sizeof(int) * table.Length);
    
    try
    {
      Marshal.Copy(table, 0, pTable, table.Length);
    
      ColorRamps_getColorRampTable(n, pTable);
    
      Marshal.Copy(pTable, table, 0, table.Length);
    }
    finally
    {
      Marshal.FreeHGlobal(pTable);
    }
