    //Create a byte array that will eventually hold our final PDF
                Byte[] bytes;
    
                //Boilerplate iTextSharp setup here
                //Create a stream that we can write to, in this case a MemoryStream
                using (var ms = new MemoryStream())
                {
    
                    //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                    using (var doc = new Document())
                    {
    
                        //Create a writer that's bound to our PDF abstraction and our stream
                        using (var writer = PdfWriter.GetInstance(doc, ms))
    
                        {
    
                            //Open the document for writing
                            doc.Open();
    
    
                            string finalHtml = string.Empty;
                           // read your html by database or from a html file here and store it into finalHtml e.g. a string
    
    
    
                            //XMLWorker also reads from a TextReader and not directly from a string
                            using (var srHtml = new StringReader(finalHtml))
                            {
    
                                //Parse the HTML
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                            }
    
    
    
                            doc.Close();
                        }
                    }
    
                    //After all of the PDF "stuff" above is done and closed but **before** we
                    //close the MemoryStream, grab all of the active bytes from the stream
                    bytes = ms.ToArray();
                }
    
    
    
    
    
    	    //clear the response
                Response.Clear();
                MemoryStream mstream = new MemoryStream(bytes);
    	    //define response content type
                Response.ContentType = "application/pdf";
    	    //give the name of file of pdf and add in to header
                Response.AddHeader("content-disposition", "attachment;filename=invoice.pdf");
                Response.Buffer = true;
                mstream.WriteTo(Response.OutputStream);
                Response.End();
