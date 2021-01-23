    public static HtmlTable GenerateHtmlTableForMail(DataTable dt)
    {
            HtmlTable retval = new HtmlTable();
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            foreach (DataColumn col in dt.Columns)
            {
                td = new HtmlTableCell();
                td.InnerText = col.ColumnName;
                tr.Cells.Add(td);
            }
            retval.Rows.Add(tr);
            foreach (DataRow row in dt.Rows)
            {
                tr = new HtmlTableRow();
                foreach (DataColumn col in dt.Columns)
                {
                    td = new HtmlTableCell();
                    td.InnerText = row[col].ToString();
                }
                retval.Rows.Add(tr);
            }
            return retval;
    }
