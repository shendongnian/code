    string dataCsv;     
    using (var csvReader = new TextFieldParser(
        dataCsv, 
        Encoding.GetEncoding("iso-8859-1"), 
        true))
    {
        csvReader.TextFieldType = FieldType.Delimited;
        csvReader.SetDelimiters(",");
        while (!csvReader.EndOfData)
        {
            try
            {
                string[] currentRow = csvReader.ReadFields();
                // turn that to a DataRow
            }
            catch (MalformedLineException ex) { }
        }
        // build the DataTable and add all DataRows 
    }
