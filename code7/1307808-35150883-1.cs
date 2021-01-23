    // To download same PDF I write below code section
    
                    Response.Clear();
                    string pdfPath = Server.MapPath(@"~\PDF\" + FileName + ".pdf");
                    WebClient client = new WebClient();
                    Byte[] buffer = client.DownloadData(pdfPath);
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                    Response.Flush();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    Response.End();
                    //Response.Redirect("Practice.aspx");
 
