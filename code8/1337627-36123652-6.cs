    void DumpResults(string path)
    {
        using (var reader = new PdfReader(path))
        {
            // need this call to parse page numbers
            reader.ConsolidateNamedDestinations();
            var bookmarks = ParseBookMarks(SimpleBookmark.GetBookmark(reader));
            var sb = new StringBuilder();
            foreach (var bookmark in bookmarks)
            {
                sb.AppendLine(string.Format(
                    "{0, -4}{1, -100}{2, -25}{3}",
                    bookmark.Number, bookmark.Title,
                    bookmark.PageNumberString, bookmark.PageNumberInteger
                ));
            }
            File.WriteAllText(outputTextFile, sb.ToString());
        }
    }
