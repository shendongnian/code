    //Code to Export data to PDF file
                public FileStreamResult ExportPdf()
                {
                    List data = new List();
                    using (DatabaseEntities db = new DatabaseEntities())
                    {
                        data = db.UserTables.ToList();
                    }
                    //convert all webgrid data to single string
                    WebGrid grid = new WebGrid(source: data, canSort: false, canPage: false);
                    string griddata = grid.GetHtml(
                            columns: grid.Columns(
                                grid.Column("UserID", "UserID"),
                                grid.Column("UserName", "User Name"),
                                grid.Column("Address", "Address"),
                                grid.Column("PostalCode", "Postal Code"),
                                grid.Column("Phone", "Phone")
                           )
                        ).ToString();
                    //display styles for webgrid table in pdf sheet
                    //because iTextSharp takes XHTML and css to pdf.so we need to pass data in XHTML format 
                    string export = String.Format(""<html><head>{0}</head><body>{1}</body></html>", "<style>table{ border-spacing: 10px; border-collapse: separate;}</style>", griddata);
                    //converting all data into bytes in UTF-8 format
                    var bytes = System.Text.Encoding.UTF8.GetBytes(export);
                    //Now prepare docment using iTextsharp module
                    //And print using PDF writer
                    using (var input = new MemoryStream(bytes))
                    {
                        var output = new MemoryStream();
                        var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50);
                        var writer = PdfWriter.GetInstance(document, output);
                        writer.CloseStream = false;
                        document.Open();
    
                    var XmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                    XmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                    document.Close();
                    output.Position = 0;
                    return new FileStreamResult(output, "application/pdf");
