    string myLine = "Sentence 1<style styles='B;fg:Green'>STYLED SENTENCE</style>Sentence 2";
    const string splitLinesRegex = @"((?<Styled>\<style[^\>]*\>[^\<\>]*\</style\>)|(?<NoStyle>[^\<\>]*))";
    
    var splitLinesMatch = Regex.Matches(myLine, splitLinesRegex, RegexOptions.Compiled);
    List<string> styledLinesBis = new List<string>();
    
    foreach (Match item in splitLinesMatch)
    {
        if (item.Length > 0)
        {
            if (!string.IsNullOrEmpty(item.Groups["Styled"].Value))
                styledLinesBis.Add(string.Format("<style styles='B'>{0}</style> ", item.Groups["Styled"].Value));
    
            if (!string.IsNullOrEmpty(item.Groups["NoStyle"].Value))
                styledLinesBis.Add(string.Format("<style styles='B;fg:Red'>{0}</style>  ", item.Groups["NoStyle"].Value));
        }
    }
