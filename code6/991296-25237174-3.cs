    var com = yourConnection.CreateCommand();
    com.CommandText = @"select col1 from YourTable where col1 in (";
    for (var i=0; i< dataNames.Length; i++)
    {
        var parName = string.Format("par{0}", i+1);
        com.Parameters.AddWithValue(parName, dataNames[i]);
        com.CommandText += parName;
        if (i+1 != dataNames.Length)
            com.CommandText += ", ";
    }
    com.CommandText += ");";
    var existingValues = new List<string>();
    using (var reader = com.ExecuteReader())
    {
        while (read.Read())
            existingValues.Add(read["col1"]);
    }
