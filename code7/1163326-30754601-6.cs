    var hTable = GCHandle.Alloc(table, GCHandleType.Pinned);
    try
    {
      ColorRamps_getColorRampTable(n, hTable.AddrOfPinnedObject());
    }
    finally
    {
      hTable.Free();
    }
