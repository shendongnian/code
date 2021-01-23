    PdfReader pdfReader = new PdfReader(bytes);
      for (int page = 1; page <= pdfReader.NumberOfPages; page++)
      {
        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        
        string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
        if (currentPageText.Contains(searthText))
        {
          // adding new WaterMark here
          Console.WriteLine("text was found on page "+i);
        }
      }
    pdfReader.Close();
