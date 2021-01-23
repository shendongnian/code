    public static DataTable GetTable(string html, string tableClass, bool firstRowContainsHeader = false)
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        string xpath = string.Format("//table[contains(@class,'{0}')]", tableClass);
        var firstTable = doc.DocumentNode.SelectSingleNode(xpath);
        if (firstTable == null) return null;
        DataTable table = new DataTable();
        var tableRows = firstTable.Descendants("tr");
        var tableData = tableRows.Skip(firstRowContainsHeader ? 1 : 0)
            .Select(row => row.Descendants("td")
                .Select((cell, index) => new { row, cell, index, cell.InnerText })
                .ToList());
        var headerCells = tableRows.First().Descendants()
            .Where(n => n.Name == "td" || n.Name == "th");
        int columnIndex = 0;
        foreach (HtmlNode cell in headerCells)
        {
            string colName = firstRowContainsHeader
                ? cell.InnerText
                : String.Format("Column {0}", (++columnIndex).ToString());
            table.Columns.Add(colName, typeof(string));
        }
        foreach (var rowCells in tableData)
        {
            DataRow row = table.Rows.Add();
            for (int i = 0; i < Math.Min(rowCells.Count, table.Columns.Count); i++)
            {
                row.SetField(i, rowCells[i].InnerText);
            }
        }
        return table;
    }
