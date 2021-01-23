    table.Rows.Cast<System.Data.DataRow>().Select(row => GridViewModel
    {
        Number = row[0].ToString(),
        DocId = row[1].ToString(),
        PartyName = row[2].ToString(),
        FilingType = row[3].ToString(),
        FilingDate = row[4].ToString(),           
    });
