    dt.AsEnumerable().ToList().ForEach(x =>
    {
    if (checkValues2.Any(t => t.StartsWith((x["Group"])))) 
    {
    newDT.ImportRow(x); //Copy
    DT.Rows.Remove(x); //Remove
    }
    });
