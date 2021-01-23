    var line = reader.ReadLine();
    var values = line.Split(';');
    if (values.Count != numColumnsExpected)
    {
        throw new System.Exception("Expected " + numColumnsExpected + " columns, only found " + values.Count + " columns for a row.");
    }
