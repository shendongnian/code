    string tempCsvFileSpec = @"C:\Users\Gord\Desktop\dump.csv";
    using (StreamWriter writer = new StreamWriter(tempCsvFileSpec))
    {
        Rfc4180Writer.WriteDataTable(rawData, writer, false);
    }
    var msbl = new MySqlBulkLoader(conn);
    msbl.TableName = "testtable";
    msbl.FileName = tempCsvFileSpec;
    msbl.FieldTerminator = ",";
    msbl.FieldQuotationCharacter = '"';
    msbl.Load();
    System.IO.File.Delete(tempCsvFileSpec);
