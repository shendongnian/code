        private string MergeLotsOfPDFs(List<byte[]> PDFs)
        {
            Document doc = new Document();
            Guid uniqueId = Guid.NewGuid();
            string tempFileName = Server.MapPath("~/__" + uniqueId.ToString() + ".pdf");
            using (FileStream ms = new FileStream(tempFileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                PdfCopy copy = new PdfCopy(doc, ms);
                doc.Open();
                int i = 0;
                foreach (byte[] PDF in PDFs)
                {
                    i++;
                    // Create a reader
                    PdfReader reader = new PdfReader(new RandomAccessFileOrArray(PDF), null);
                    // Cycle through all the pages
                    for (int currentPageNumber = 1; currentPageNumber <= reader.NumberOfPages; ++currentPageNumber)
                    {
                        // Read a page
                        PdfImportedPage curPg = copy.GetImportedPage(reader, currentPageNumber);
                        // Add the page over to the rest of them
                        copy.AddPage(curPg);
                        // This is a lie, it still costs money, hue hue hue :)~
                        copy.FreeReader(reader);
                    }
                    reader.Close();
                }
                // Close the document
                doc.Close();
                // Close the document
                copy.Close();
            }
            // Return temp file path
            return tempFileName;
        }
