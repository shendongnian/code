    protected void ExportToExcel(GridView gv)
            {
                Response.Clear();
                Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=YourFileName.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (var sw = new StringWriter())
            {
                var hw = new HtmlTextWriter(sw);
                //To Export all pages
                gv.AllowPaging = false;
                gv.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex%2 == 0)
                        {
                            cell.BackColor = gv.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gv.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                gv.RenderControl(hw);
                //style to format numbers to string
                var style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
