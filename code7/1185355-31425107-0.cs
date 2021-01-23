    var rows1 = dt.AsEnumerable();
    var rows2 = posTable.AsEnumerable();
    dt = rows1 
        .Where(r1 => !rows2.Any(r2 => r1.ItemArray.SequenceEqual(r2.ItemArray)))
        .CopyToDataTable();
