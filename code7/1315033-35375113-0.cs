    public static string GetSubstringStartingWithFirstAlphaCharacter(this string toEvaluate)
            {
                const string pattern = "([a-zA-Z])(.+)";
    
                var regex = new Regex(pattern);
    
                return regex.Match(toEvaluate).Value;
            }
