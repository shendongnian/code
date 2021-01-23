    public IEnumerable<CardaxDataObject> ReadCardaxCsvFile(string filename)
    {
       //no try block at this level. Catch that in the method that calls this method
        return EasyCSV.FromFile(cardaxCsvPath)
              .Where(r => r.Any(c => !string.IsNullOrEmpty(c)))
              // You may want to put a try/catch inside the `Select()` projection, though.
              // It would allow you continue if you fail to parse an individual record
              .Select(r => CardaxDataObject() {
                    cardaxCsvTest2.EventID = int.Parse(r[0]),
                    cardaxCsvTest2.FTItemID = int.Parse(r[1]),
                    cardaxCsvTest2.PayrollNumber = int.Parse(r[2]),
                    cardaxCsvTest2.EventDateTime = DateTinme.Parse(r[3]),
                    cardaxCsvTest2.CardholderFirstName = r[4],
                    cardaxCsvTest2.CardholderLastName = r[5]
             });      
    }
