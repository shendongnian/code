         // CSV Generic List    
             CSVExportGeneric<BookFxDownload> _csv = new CSVExportGeneric<BookFxDownload>(Download);
                // Convert to byte array
                                    byte[] a = _csv.ExportToBytes().ToArray();
        // the lines are supposed to be in the same order
                                    Response.Clear();
                                    Response.Buffer = true;
                                    Response.ClearHeaders();
                                    Response.ClearContent();
                
                                    //Response.AppendHeader("content-disposition", fileName);
                                    Response.ContentType = "application/csv";
                                    Response.AddHeader("Content-Length", a.Length.ToString());
    //fileName = <yourname>.<extension>
                                    Response.AppendHeader("content-disposition", "attachment; filename=" +"\"" + fileName + "\"");
                                    Response.Charset = "";
                                    Response.OutputStream.Write(a, 0, a.Length);
                                    Response.Flush();
                                    Response.Close();
