    protected void Button2_Click(object sender, EventArgs e)
            {
                try
                {
                    string htmlContent = "<div> PDF Code </div>"; // you html code (for example table from your page)
                    Document document = new Document();
                    string FileName = Guid.NewGuid().ToString();
                    PdfWriter.GetInstance(document, new FileStream("C:\\...\\...\\PDF\\" + FileName + ".pdf", FileMode.Create));
                    document.Open();
                    HTMLWorker worker = new HTMLWorker(document);
                    worker.Parse(new StringReader(htmlContent));
                    document.Close();
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ".pdf");
                    Response.TransmitFile(Server.MapPath(@"~\PDF\" + FileName + ".pdf"));
                    Response.End();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }
            }
