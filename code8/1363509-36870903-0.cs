    string path1 = Path.Combine(HttpContext.Server.MapPath("~/App_Data/" + sessionManagement.GetUserId()), Path.GetFileName(model.FileName));
                    FileStream stream = System.IO.File.Open(path1, FileMode.Open, FileAccess.Read);
    
                    IExcelDataReader reader = null;
                    DataSet result = new DataSet();
                    try
                    {
                        if (path1.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                            reader.IsFirstRowAsColumnNames = true;
                        }
                        if (path1.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            reader.IsFirstRowAsColumnNames = true;
                        }
                        result = reader.AsDataSet();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Dispose();
       }
                    DataTable dt = result.Tables[0];
