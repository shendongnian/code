     public override void VerifyRenderingInServerForm(Control control)
            {
                /* Verifies that the control is rendered */
            }
            private void GetInPDf()
            {
                if (gridview.Rows.Count > 0)
                {
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
    
                    gridview.RenderControl(htw);
    
                    var mem = new MemoryStream();
    
                    Document document = new Document(PageSize.LETTER, 50, 50, 50, 50);
                    PdfWriter.GetInstance(document, mem);
    
                    document.Open();
    
                    iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                    hw.Parse(new StringReader(sw.ToString()));
                    document.Close();
    
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);
    
                    Response.BinaryWrite(mem.ToArray());
                    Response.End();
                    Response.Flush();
                    Response.Clear();
                }
            }
