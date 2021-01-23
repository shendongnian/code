    buf = Regex.Replace(entry, @"<prod(?<attr>.*?)>(?<text>.*?)</prod>", match => {
        var attrText = match.Groups["attr"].Value;
        var text = match.Groups["text"].Value;
    
        // Now, parse your attributes
        var attributes = Regex.Matches(@"(?<name>\w+)\s*=\s*(['""])(?<value>.*?)\1")
                              .Cast<Match>()
                              .ToDictionary(
                                   m => m.Groups["name"].Value,
                                   m => m.Groups["value"].Value);
        string category;
        if (attributes.TryGetValue("cat", out category))
        {
            // Your SQL here etc...
            var label = GetLabelForCategory(category)
            return String.Format("<span class='prod'>{0}</span><span class='cat'>{1}</span>", WebUtility.HtmlEncode(text), WebUtility.HtmlEncode(label));
        }
        // Generate the result string
        return String.Format("<span class='prod'>{0}</span>", WebUtility.HtmlEncode(text));
    });
