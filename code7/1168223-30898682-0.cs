    private string ParseAttribute(string input, string attributeName)
    {
        int startIndex = input.IndexOf(attributeName + "=\"");
        if (startIndex >= 0)
        {
            startIndex += attributeName.Length + 2;
            int endIndex = input.IndexOf('"', startIndex);
            if (endIndex >= 0)
                return input.Substring(startIndex, endIndex - startIndex);
        }
        return string.Empty;
    }
    // usage
    string html = "<p><a rel=\"nofollow\" data-xxx=\"797998\" href=\"http://www.stackoverflow.com\">StackOverflow</a> for the win</p>";
    Console.WriteLine(ParseAttribute(html, "href"));
