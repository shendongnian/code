    List<BookMark> ParseBookMarks(IList<Dictionary<string, object>> bookmarks)
    {
        int page;
        var result = new List<BookMark>();
        foreach (var bookmark in bookmarks)
        {
            // add top-level bookmarks
            var stringPage = bookmark["Page"].ToString();
            if (Int32.TryParse(stringPage.Split()[0], out page))
            {
                result.Add(new BookMark() {
                    Title = bookmark["Title"].ToString(),
                    PageNumberString = stringPage,
                    PageNumberInteger = page
                });
            }
            // recurse
            if (bookmark.ContainsKey("Kids"))
            {
                var kids = bookmark["Kids"] as IList<Dictionary<string, object>>;
                if (kids != null && kids.Count > 0)
                {
                    result.AddRange(ParseBookMarks(kids));
                }
            }
        }
        return result;
    }
