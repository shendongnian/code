        string strText = string.Empty;
            try
            {
                PdfReader reader = new PdfReader(filePath);
                string prevPage = "";
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    Widgets.ProgressBar(page);
                    //Convert PDF to Text
                    ITextExtractionStrategy its = new SimpleTextExtractionStrategy();
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                    if (prevPage != s)
                        strText += s;
                    prevPage = s;
                }
                reader.Close();
                Console.WriteLine("File Extracted");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.Clear();
            }
            return strText;
        }
