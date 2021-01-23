            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Subject");
                dt.Columns.Add("Category");
                dt.Columns.Add("CPT");
                dt.Columns.Add("Modifier");
                dt.Columns.Add("Dx");
                dt.Columns.Add("GuideLine");
                dt.Columns.Add("Insurance");
                dt.Columns.Add("FilePath");
                string path = Server.MapPath("Image/stock-illustration-1977033-dandelion-in-the-wind.jpg");
            
                dt.Rows.Add("Billing Steps", "Billing", "NA", "NA", "Billing Steps is very easy", "NA", "NA", path);
                dt.Rows.Add("Billing Steps", "Billing", "NA", "NA", "Billing Steps is very easy", "NA", "NA", "");
                dt.AcceptChanges();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    string WorkSheetName = "Sheet1";
                    IXLWorksheet WorkSheet = wb.Worksheets.Add(dt, WorkSheetName);
                    Bitmap Image = null;
                    long ImgHeight = 100;
                    long ImgWidth = 100;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(Convert.ToString(dt.Rows[i]["FilePath"]));
                        if (bitmap != null)
                        {
                            var stream = new System.IO.MemoryStream();
                            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
                            if (stream != null)
                            {
                                stream.Position = 0;
                                XLPicture pic = new XLPicture
                                {
                                    NoChangeAspect = true,
                                    NoMove = false,
                                    NoResize = false,
                                    ImageStream = stream,
                                    Name = "image",
                                    EMUOffsetX = 4,
                                    EMUOffsetY = 6,
                                    MaxHeight = 100,
                                    MaxWidth = 100,
                                    PaddingX = 10,
                                    PaddingY = 10
                                };
                                XLMarker fMark = new XLMarker
                                {
                                    ColumnId = 8,
                                    RowId = i +1 
                                };
                                pic.AddMarker(fMark);
                                WorkSheet.AddPicture(pic);
                            }
                        }
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=download.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
