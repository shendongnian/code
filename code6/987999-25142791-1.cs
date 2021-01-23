    public void BuildHTMLTable(DataTable dt)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter w = new HtmlTextWriter(sw);
    
        Table tbl = new Table();
    
        // create table header
        TableHeaderRow thr = new TableHeaderRow();
        thr.TableSection = TableRowSection.TableHeader; // ADD THIS LINE
        foreach (DataColumn col in dt.Columns)
        {
            TableHeaderCell thc = new TableHeaderCell();
            thc.Text = col.Caption;
            thr.Cells.Add(thc);
        }
        tbl.Rows.AddAt(0, thr);
    
        // write out each data row
        foreach (DataRow row in dt.Rows)
        {
            TableRow tr = new TableRow();
            foreach (var value in row.ItemArray)
            {
                TableCell td = new TableCell();
                td.Text = value.ToString();
                tr.Controls.Add(td);
            }
            tbl.Rows.Add(tr);
        }
    
        // Create table footer
        TableFooterRow tfr = new TableFooterRow();
        tfr.TableSection = TableRowSection.TableFooter; // ADD THIS LINE
        foreach (DataColumn col in dt.Columns)
        {
            TableCell th = new TableCell();
            th.Text = col.Caption;
            tfr.Cells.Add(th);
        }
        tbl.Rows.Add(tfr);
    
        // Renter the table to html writer
        tbl.RenderControl(w);
        // copy html writer to a string variable
        tableString = sw.ToString();
    }
