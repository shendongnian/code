    ssPagesPDF = new RLPDFRecordList(null);
            ssErrors = "";
            //Document document = null;
            PdfImportedPage importedPage = null;
            try
            {
                int TotalPages = 0;
                MssCountPagesPDF(ssPDF.ssSTPDF.ssBinaryData, out TotalPages, out ssErrors);
                if (TotalPages == 0)
                    throw new Exception("The PDF don't have any page!");
                for (int i = 1; i <= TotalPages; i++)
                {
                    PdfReader reader = new PdfReader(ssPDF.ssSTPDF.ssBinaryData, System.Text.ASCIIEncoding.ASCII.GetBytes(ssPDF.ssSTPDF.ssPDFPassword));
                    // Capture the correct size and orientation for the page:
                    using (MemoryStream target = new MemoryStream())
                    {
                        using (Document document = new Document(reader.GetPageSizeWithRotation(i)))
                        {
                            using (PdfCopy pdfCopyProvider = new PdfCopy(document, target))
                            {
                                document.Open();
                                // Extract the desired page number:
                                importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                                pdfCopyProvider.AddPage(importedPage);
                                //close the document
                                document.Close();
                                reader.Close();
                                //Append PDF to the RecordList
                                RCPDFRecord rcPDF = new RCPDFRecord();
                                rcPDF.ssSTPDF.ssBinaryData = target.ToArray();
                                ssPagesPDF.Append(rcPDF);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ssErrors = exception.ToString();
                throw new Exception("There has an unexpected exception" +
                      " occured during the pdf creation process.", exception);
            }
