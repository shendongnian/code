    public static byte[] PdfJoin(List<String> pdfs)
        {
            byte[] mergedPdf = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (iTextSharp.text.Document document = new iTextSharp.text.Document())
                {
                    using (iTextSharp.text.pdf.PdfCopy copy = new iTextSharp.text.pdf.PdfCopy(document, ms))
                    {
                        document.Open();
                        for (int i = 0; i < pdfs.Count; ++i)
                        {
                            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pdfs[i]);
                            // loop over the pages in that document
                            int n = reader.NumberOfPages;
                            for (int page = 0; page < n; )
                            {
                                copy.AddPage(copy.GetImportedPage(reader, ++page));
                            }
                        }
                    }
                }
                mergedPdf = ms.ToArray();
            }
            return mergedPdf;
        }
     public static byte[] PdfJoin(List<byte[]> pdfs)
        {
            byte[] mergedPdf = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (iTextSharp.text.Document document = new iTextSharp.text.Document())
                {
                    using (iTextSharp.text.pdf.PdfCopy copy = new iTextSharp.text.pdf.PdfCopy(document, ms))
                    {
                        document.Open();
                        for (int i = 0; i < pdfs.Count; ++i)
                        {
                            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pdfs[i]);
                            // loop over the pages in that document
                            int n = reader.NumberOfPages;
                            for (int page = 0; page < n; )
                            {
                                copy.AddPage(copy.GetImportedPage(reader, ++page));
                            }
                        }
                    }
                }
                mergedPdf = ms.ToArray();
            }
            return mergedPdf;
        }
