    string getFinalSMSString(string smsTemplate) 
    {
        string result = smsTemplate;
        foreach (Match m in Regex.Matches(smsTemplate, @"{(\w+\s*\w*?)}"))
        {
            string keyword = m.Groups[1].Value;
            if (KeywordLookup.ContainsKey(keyword))
            {
                result = result.Replace(m.Value, KeywordLookup[keyword]);
            }
        }
        return result;
    } 
