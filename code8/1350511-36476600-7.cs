    StringBuilder sb = new StringBuilder();
    using (Html.Table table = new Html.Table(sb))
    {
        foreach (var invalidCompany in mailMessageObject.InvalidCompanies)
        {
            using (Html.Row row = table.AddRow())
            {
                row.AddCell(invalidCompany.BusinessName);
                row.AddCell(invalidCompany.SwiftBIC);
                row.AddCell(invalidCompany.IBAN);
            }
        }
    }
    string finishedTable = sb.ToString();
