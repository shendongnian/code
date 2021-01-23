            string text = @"Bar 4111-1111 1111 1111";
            string pattern = @"((?<CCNum>4\d{3}[ -]?(\d{4}[ -]?){2}\d{4}).*Bar)|(.*Bar.*(?<CCNum>4\d{3}[ -]?(\d{4}[ -]?){2}\d{4}))";
            int CCNum;
            Match match = new Regex(pattern, RegexOptions.Singleline).Match(text);
            if (match.Success)
            {
                if (Int32.TryParse (match.Groups["CCNum"].Value.Replace(" ", "").Replace("-",""),out CCNum));
                {
                    // here is your clean CC Number
                }
                
            }
