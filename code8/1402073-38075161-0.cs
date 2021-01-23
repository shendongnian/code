    private void printBytes()
            {
                
                string fileName = @"D:\Byte.pdf";
    
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
    
                Byte[] bytes1 = { 0x01, 0x20, 0x20, 0x20 };
                Byte[] bytes2 = { 0x31, 0x32, 0x33 };
                Byte[] bytes3 = Combine(bytes1, bytes2);
    
                string result = string.Empty;
                for (int i = 0; i < bytes3.Count(); i++)
                {
                    result = result + bytes3[i].ToString() + " ";
                }
    
                try
                {
                    // Step 1: Creating System.IO.FileStream object
                    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    // Step 2: Creating iTextSharp.text.Document object
                    using (Document doc = new Document())
                    // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                    // It helps to write the Document to the Specified FileStream
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        // Step 4: Openning the Document
                        doc.Open();
    
                        // Step 5: Adding a paragraph
                        // NOTE: When we want to insert text, then we've to do it through creating paragraph
    
                        doc.Add(new Paragraph("The sequence Bytes:"));
                        doc.Add(new Paragraph(result));
    
                        // Step 6: Closing the Document
                        doc.Close();
                    }
                }
                // Catching iTextSharp.text.DocumentException if any
                catch (DocumentException de)
                {
                    throw de;
                }
            }
