    protected HtmlTable CopyTable(HtmlTable copyFromTable)
    {
        if (copyFromTable != null && copyFromTable.Rows.Count > 0)
        {
            var copyToTable = new HtmlTable();
            HtmlTableRow copyRow;
            HtmlTableCell copyCell;
            for (int i = 0; i < copyFromTable.Rows.Count - 1; i++)
            {
                copyRow = new HtmlTableRow();
                for (int j = 0; j < copyFromTable.Rows[i].Cells.Count - 1; j++)
                {
                    copyCell = new HtmlTableCell();
                    copyCell.InnerHtml = copyFromTable.Rows[i].Cells[j].InnerHtml;
                    copyRow.Cells.Add(copyCell);
                }
                copyToTable.Rows.Add(copyRow);
            }
            
            return copyToTable;
        }
        return null;
    }
