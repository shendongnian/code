                iTextSharp.text.Table table = new iTextSharp.text.Table(gvdPL.Columns.Count);//create first table
                table.Padding = 4;
                table.Cellpadding = 4;
                int[] widths = new int[gvdPL.Columns.Count];//setting column width
                for (int x = 0; x < gvdPL.Columns.Count; x++)
                {
                    widths[x] = (int)gvdPL.Columns[x].ItemStyle.Width.Value;
                    string cellText = Server.HtmlDecode(gvdPL.HeaderRow.Cells[x].Text);
                    iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
                    //cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#008000"));
                    table.AddCell(cell);
                    table.DefaultHorizontalAlignment = 1;
                    cell.HorizontalAlignment = 1;
                }
                table.SetWidths(widths);
                int ab = gvdPL.Rows.Count;  //Transfer rows from GridView to table and column header
                string[] labelname = new string[3];
                labelname[0] = "lblPurchaseDate";
                labelname[1] = "lblPurchaseOrder";
                labelname[2] = "lblInvoice";
                for (int i = 0; i < gvdPL.Rows.Count; i++)
                {
                    if (gvdPL.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        for (int j = 0; j < gvdPL.Columns.Count; j++)
                        {
                            Label lbld = (Label)gvdPL.Rows[i].Cells[j].FindControl(labelname[j]);
                            //string cellText = Server.HtmlDecode(GrdSOOthers.Rows[i].Cells[j].Text));
                            iTextSharp.text.Cell cell = new iTextSharp.text.Cell(lbld.Text);
                            table.AddCell(cell);
                            table.DefaultHorizontalAlignment = 1;
                            cell.HorizontalAlignment = 1;
                        }
                    }
                }//filling first table completed// close for purchase// open for sale
            
            
                gvdSale.AllowPaging = false;
                iTextSharp.text.Table table1 = new iTextSharp.text.Table(gvdSale.Columns.Count);  /created second table for second gridview
                table1.Padding = 4;
                table1.Cellpadding = 4;
                //Set the column widths 
                int[] widths1 = new int[gvdSale.Columns.Count];
                for (int x = 0; x < gvdSale.Columns.Count; x++)
                {
                    widths1[x] = (int)gvdSale.Columns[x].ItemStyle.Width.Value;
                    string cellText = Server.HtmlDecode(gvdSale.HeaderRow.Cells[x].Text);
                    iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
                    //cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#008000"));
                    table1.AddCell(cell);
                    table1.DefaultHorizontalAlignment = 1;
                    cell.HorizontalAlignment = 1;
                }
                table1.SetWidths(widths1);
                int ab3 = gvdSale.Rows.Count;
              
                string[] labelname1 = new string[3];  //Transfer rows from GridView to table and its header
        
                labelname1[0] = "lblSaleDate";
                labelname1[1] = "lblsalecode";
                labelname1[2] = "lblsaleinvoice";
                for (int i = 0; i < gvdSale.Rows.Count; i++)
                {
                    if (gvdSale.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        for (int j = 0; j < gvdSale.Columns.Count; j++)
                        {
                            Label lbld = (Label)gvdSale.Rows[i].Cells[j].FindControl(labelname1[j]);
                            //string cellText = Server.HtmlDecode(GrdSOOthers.Rows[i].Cells[j].Text));
                            iTextSharp.text.Cell cell = new iTextSharp.text.Cell(lbld.Text);
                            table1.AddCell(cell);
                            table1.DefaultHorizontalAlignment = 1;
                            cell.HorizontalAlignment = 1;
                        }
                    }
                }
                DataTable dt2 = (DataTable)Session["sale"];
            
            //close for sale
