    private void PrintTable(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            Response.Write(row[column] + "<br />");
        }
    }
