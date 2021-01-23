    protected void FILL_DATA(object sender, EventArgs e)
    {
        DataTable IACS = new DataTable();
        IACS = GenerateTransposedTableinCsharp(generateIacs());
        for (int i = 6; i <= 8; i++)
        {
            String rowtext = "A0" + i;
            for (int j = 1; j <= 14; j++)
            {
                String text = rowtext + j;
                HtmlTableCell cell = tableIACS.FindControl(text) as HtmlTableCell;
                if (cell != null)
                    cell.InnerText = IACS.Rows[i - 5].Field<string>(j);
            }
        }
    }
