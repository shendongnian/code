    foreach (XElement element in voiceXmlDocument.Descendants("prompt").ToArray())
    {
        // convert the element to a string and see to see if there are any instances
        // of pause placeholders in it
        string elementAsString = element.ToString();
        MatchCollection matches = Regex.Matches(elementAsString, @"\[pause=(\d+)]");
        if (matches == null || matches.Count == 0)
            continue;
        // if there were no matches or an empty set, move on to the next one
    
        // iterate through the indexed matches
        for (int i = 0; i < matches.Count; i++)
        {
            int pauseValue = 0; // capture the original pause value specified by the user
            int pauseMilliSeconds = 1000; // if things go wrong, use a 1 second default
            if (matches[i].Groups.Count == 2) // the value is expected to be in the second group
            {
                // if the value could be parsed to an integer, convert it from 1/8 seconds to milliseconds
                if (int.TryParse(matches[i].Groups[1].Value, out pauseValue))
                    pauseMilliSeconds = pauseValue * 125; 
            }
    
            // replace the specific match with the new <break> tag content
            elementAsString = elementAsString.Replace(matches[i].Value, string.Format(@"<break time=""{0}ms""/>", pauseMilliSeconds));
        }
    
        // finally replace the element by parsing
        element.ReplaceWith(XElement.Parse(elementAsString));
    }
