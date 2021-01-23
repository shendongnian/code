      public string[] GetLines(byte[] outBytes)
        {
            string resultPdfText = "";
            string[] lines = null;
            try
            {
                MemoryStream outPDF = new MemoryStream();
                using (PdfReader pdfr = new PdfReader(outBytes))
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    iTextSharp.text.Document.Compress = true;
                    PdfWriter writer = PdfWriter.GetInstance(doc, outPDF);
                    doc.Open();
                    for (int i = 1; i <= pdfr.NumberOfPages; i++)
                    {
                        resultPdfText += PdfTextExtractor.GetTextFromPage(pdfr, i, new LocationTextExtractionStrategy());
                    }
                    lines = resultPdfText.Split('\n');
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lines;
        }
