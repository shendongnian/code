    // Show the output
    for (var i = 0; i < myTable.Columns.Count - 1; i++)
        Console.Write("{0}, ", myTable.Columns[i]);
    Console.WriteLine("{0}", myTable.Columns[myTable.Columns.Count - 1]);
    foreach (var row in myTable.AsEnumerable())
        Console.WriteLine(string.Join(", ", row.ItemArray.Select(x => x == null ? "<null>" : x.ToString())));
