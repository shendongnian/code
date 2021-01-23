    public void ExtractPage(string sourcePdfPath, string outputPdfPath, int pageNumber)
                {
                    PdfReader reader = null;
                    Document document = null;
                    PdfCopy pdfCopyProvider = null;
                    PdfImportedPage importedPage = null;
        
                    try
                    {
                        // Intialize a new PdfReader instance with the contents of the source Pdf file:
                        reader = new PdfReader(sourcePdfPath);
        
                        // Capture the correct size and orientation for the page:
                        document = new Document(reader.GetPageSizeWithRotation(pageNumber));
        
                        // Initialize an instance of the PdfCopyClass with the source
                        // document and an output file stream:
                        pdfCopyProvider = new PdfCopy(document,
                            new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
        
                        document.Open();
        
                        // Extract the desired page number:
                        importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber);
                        pdfCopyProvider.AddPage(importedPage);
                        document.Close();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
