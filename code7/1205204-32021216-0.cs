    public void CardaxCsvFileReader()
    {
        try 
        {
            string cardaxCsvPath = (@"C:\Cardax2WkbTest\Cardax\CardaxTable.csv");
            Globals.CardaxQueryResult =
               EasyCSV.FromFile(cardaxCsvPath)
                  .Where(r => r.Any(c => !string.IsNullOrEmpty(c)))
                  .Select(r => CardaxDataObject() {
                        cardaxCsvTest2.EventID = int.Parse(r[0]),
                        cardaxCsvTest2.FTItemID = int.Parse(r[1]),
                        cardaxCsvTest2.PayrollNumber = int.Parse(r[2]),
                        cardaxCsvTest2.EventDateTime = DateTinme.Parse(r[3]),
                        cardaxCsvTest2.CardholderFirstName = r[4],
                        cardaxCsvTest2.CardholderLastName = r[5]
                  }).ToList();      
        }
        catch (Exception)
        {
            myLog.Error("Unable to open/read Cardax simulated punch csv file! " +
                "File already open or does not exist: \"{0}\"", cardaxCsvPath);
        }
    }
