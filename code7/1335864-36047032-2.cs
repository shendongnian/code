    //get all the data
    int dataCount = sourceData.Count();
    var rows = new DataRow[dataCount];
    DataTable destTableDT = new DataTable();
    destTableDT.Load(reader);
    for (int x = 0; x < dataCount; x++)
    {
        var dataRow = destTableDT.NewRow();
        dataRow.ItemArray = mapper.Select(m => m.Item2.Invoke(sourceData[x], m.Item1))
                                  .ToArray();
        rows[x] = dataRow;
    }
