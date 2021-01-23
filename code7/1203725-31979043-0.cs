    List<string> words2 = new List<string>();                
    string CurrentPage = null;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                CurrentPage = PdfTextExtractor.GetTextFromPage(reader, page);
               //here split the all data of the page in the form of line and store in the string array
                words2.AddRange(CurrentPage.Split('\n'));
            }` 
    //if you want an array at the end.
    string[] words3 = words2.ToArray();
