    void ProcessPdf(string path)
    {
        using (var reader = new PdfReader(path))
        {
            // need this call to parse page numbers
            reader.ConsolidateNamedDestinations();
            var bookmarks = ParseBookMarks(SimpleBookmark.GetBookmark(reader));
            for (int i = 0; i < bookmarks.Count; ++i)
            {
                int page = bookmarks[i].PageNumberInteger;
                int nextPage = i + 1 < bookmarks.Count
                    // if not top of page will be missing content
                    ? bookmarks[i + 1].PageNumberInteger - 1 
                    /* alternative is to potentially add redundant content:
                    ? bookmarks[i + 1].PageNumberInteger
                    */
                    : reader.NumberOfPages;
                string range = string.Format("{0}-{1}", page, nextPage);
                // DEMO!
                if (i < 10)
                {
                    var outputPath = Path.Combine(OUTPUT_DIR, bookmarks[i].GetFileName());
                    using (var readerCopy = new PdfReader(reader))
                    {
                        var number = bookmarks[i].Number;
                        readerCopy.SelectPages(range);
                        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
                        {
                            using (var document = new Document())
                            {
                                using (var copy = new PdfCopy(document, stream))
                                {
                                    document.Open();
                                    int n = readerCopy.NumberOfPages;
                                    for (int j = 0; j < n; )
                                    {
                                        copy.AddPage(copy.GetImportedPage(readerCopy, ++j));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
