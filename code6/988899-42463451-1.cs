     protected void btnExportToExcel_Click(object sender, EventArgs e)
            {
                try
                {
                    string mySqlQuery = GenerateQuery();
                    List<Product> myGridData = GetGridData(mySqlQuery);
                    grdDisplay.DataSource = myGridData;
                    grdDisplay.DataBind();
                    ExcelPackage excel = new ExcelPackage();
                    var workSheet = excel.Workbook.Worksheets.Add("Product");
                    var totalCols = grdDisplay.Rows[0].Cells.Count;
                    var totalRows = myGridData.Count;
                    var headerRow = grdDisplay.HeaderRow;
                    ///Ignoring the first three columns, Since first three columns are edit, search and history
                    for (var i = 3; i < totalCols; i++)
                    {
                        workSheet.Cells[1, i].Value = grdDisplay.Columns[i].HeaderText;
                    }
                    for (var j = 1; j <= totalRows; j++)
                    {
                        ///Ignoring the first three columns, Since first three columns are edit, search and history
                        for (var i = 3; i < totalCols; i++)
                        {
                            var product = myGridData.ElementAt(j - 1);
                            string hdrTextVal = product.GetType().GetProperty(grdDisplay.Columns[i].HeaderText).Name;
                            if(hdrTextVal == "col5" || hdrTextVal == "col6")
                            {
                                workSheet.Cells[j + 1, i].Style.Numberformat.Format = "MM/DD/YYYY";
                            }
                            if (hdrTextVal == "col7" || hdrTextVal == "col8")
                            {
                                workSheet.Cells[j + 1, i].Style.Numberformat.Format = "hh:mm";                            
                            }
                            workSheet.Cells[j + 1, i].Value = product.GetType().GetProperty(grdDisplay.Columns[i].HeaderText).GetValue(product, null);
                        }
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;  filename=Product-Export.xlsx");
                        excel.SaveAs(memoryStream);
                        memoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
                catch (ThreadAbortException exc)
                {                
                }
                catch (Exception ex)
                {
                }            
            }
