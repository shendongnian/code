     public static string CleanAllWhiteSpace(string messyJson)
            {
                return (Regex.Replace(messyJson, @"(\s)+|(\n)+|(\r)+|(\t)+", ""));
            }
    
            public static string removeEscapedQuotes(string escapedString)
            {
                return (Regex.Replace(escapedString, "\\\"", "\""));
            }
