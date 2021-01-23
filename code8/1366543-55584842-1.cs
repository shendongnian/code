            try
            {
                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }
                REF_User oREF_User = new REF_User();
                oREF_User = (REF_User)Session["LoggedUser"];
                string pdfFilePath = Server.MapPath("~/FileUpload/" + oREF_User.USER_ID + "");
                if (Directory.Exists(pdfFilePath))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(pdfFilePath);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    Directory.Delete(pdfFilePath);
                }
                Directory.CreateDirectory(pdfFilePath);
                string path = Server.MapPath("~/FileUpload/" + oREF_User.USER_ID + "/");
                if (Path.GetExtension(FileUpload1.FileName) == ".xlsx")
                {
                    string fullpath1 = path + Path.GetFileName(FileUpload1.FileName);
                    if (FileUpload1.FileName != "")
                    {
                        FileUpload1.SaveAs(fullpath1);
                    }
                    FileStream Stream = new FileStream(fullpath1, FileMode.Open);
                    IExcelDataReader ExcelReader = ExcelReaderFactory.CreateOpenXmlReader(Stream);
                    DataSet oDataSet = ExcelReader.AsDataSet();
                    Stream.Close();
                    bool result = false;
                    foreach (System.Data.DataTable oDataTable in oDataSet.Tables)
                    {
                      //ToDO code 
                    }
                    oBL_PlantTransactions.InsertList(oListREF_PlantTransactions, null);
                    ShowMessage("Successfully saved!", REF_ENUM.MessageType.Success);
                }
                else
                {
                    ShowMessage("File Format Incorrect", REF_ENUM.MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Please check the details and submit again!", REF_ENUM.MessageType.Error);
                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }
            }
