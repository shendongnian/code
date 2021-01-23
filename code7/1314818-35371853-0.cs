    //Write out the header
    var csv = new CsvWriter(textWriter);
    csv.WriteField("A Column Data");
    csv.WriteField("B (Empty)");
    csv.WriteField("C (Empty)");
    csv.WriteField("D (Empty)");
    csv.WriteField("E (Empty)");
    csv.WriteField("F Column Data");
    csv.WriteField("G Column Data");
    csv.NextRecord(); //Newline
            
    foreach (var item in dataList)
    {
        csv.WriteRecord(item.PropertyA);
        csv.WriteRecord(string.Empty);
        csv.WriteRecord(string.Empty);
        csv.WriteRecord(string.Empty);
        csv.WriteRecord(string.Empty);
        csv.WriteRecord(item.PropertyB);
        csv.WriteRecord(item.PropertyC);
        csv.NextRecord();
    }
