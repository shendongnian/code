    private void SplitPdfButton_Click(object sender, EventArgs e)
            {
                try
                {
                    ExtractPage(SourceTextBox.Text, DestinationTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public void ExtractPage(string sourcePath, string outputPath)
            {
                int startPage = 1;
                int endPage = 6;
    
                    for (int index = startPage; index <= endPage; index++)
                    {
    
                        PdfReader objReader = new PdfReader(sourcePath + ".pdf");
                        Document objDocument = new Document(objReader.GetPageSizeWithRotation(startPage));
    
                        string destination = Path.Combine(outputPath, index + ".pdf");
                        PdfCopy pdfCopyProvider = new PdfCopy(objDocument, new FileStream(destination, FileMode.Create));
                        objDocument.Open();
    
                        PdfImportedPage importedPage = pdfCopyProvider.GetImportedPage(objReader, index);
                        pdfCopyProvider.AddPage(importedPage);
                        objDocument.Close();
                        objReader.Close();
                    }
                
                MessageBox.Show(@"Splitting successful!");
            }
