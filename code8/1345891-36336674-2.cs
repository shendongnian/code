      //export to excel datatable
                var dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Country");
                dataTable.Columns.Add("City");
    
                dataTable.Rows.Add("1", "Micheal", "USA", "Washington");
                dataTable.Rows.Add("2", "Smith", "UK", "London");
                dataTable.Rows.Add("3", "Martin", "AUS", "Sydney");
    
    
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
    
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                Response.AddHeader("content-disposition", "attachment;filename=testExport.xls");
                Response.ContentEncoding = Encoding.UTF8;
                Response.Charset = "";
    
                //Set Fonts
                Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
                Response.Write("<BR><BR><BR>");
    
                //Sets the table border, cell spacing, border color, font of the text, background,
                //foreground, font height
                Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
    
                // Check not to increase number of records more than 65k according to excel,03
                if (dataTable.Rows.Count <= 65536)
                {
                    // Get DataTable Column's Header
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        //Write in new column
                        Response.Write("<Td>");
    
                        //Get column headers  and make it as bold in excel columns
                        Response.Write("<B>");
                        Response.Write(column);
                        Response.Write("</B>");
                        Response.Write("</Td>");
                    }
    
                    Response.Write("</TR>");
    
                    // Get DataTable Column's Row
                    foreach (DataRow dtRow in dataTable.Rows)
                    {
                        //Write in new row
                        Response.Write("<TR>");
    
                        for (int i = 0; i <= dataTable.Columns.Count - 1; i++)
                        {
                            Response.Write("<Td>");
                            Response.Write(dtRow[i].ToString());
                            Response.Write("</Td>");
                        }
    
                        Response.Write("</TR>");
                    }
                }
    
                Response.Write("</Table>");
                Response.Write("</font>");
    
                Response.Flush();
                Response.End();
