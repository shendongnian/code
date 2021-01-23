       public Stream displayPDF(string pdfName)
        {
                        MemoryStream ms = new MemoryStream();
                        ms.Write(Service.Properties.Resources.testFile, 0, Service.Properties.Resources.testFile.Length);
                        ms.Position = 0;
                        WebOperationContext.Current.OutgoingResponse.ContentType = "applicaiton/pdf";
                        WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-disposition", "inline; filename=" + pdfName);
                        return ms;
                         
        }
