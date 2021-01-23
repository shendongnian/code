            const char dollar = '$';
            const char underscore = '_';
            var item = "Hello_To_The$Great_World";
            var aTokens = new List<string>();
            int dollarIndex = item.IndexOf(dollar);
            if (dollarIndex >= 0)
            {
                int lastUnderscoreIndex = item.LastIndexOf(underscore, dollarIndex);
                if (lastUnderscoreIndex >= 0)
                {
                    aTokens.AddRange(item.Substring(0, lastUnderscoreIndex).Split(underscore));
                    aTokens.Add(item.Substring(lastUnderscoreIndex + 1));
                }
                else
                {
                    aTokens.Add(item);
                }
            }
            else
            {
                aTokens.AddRange(item.Split(underscore));
            }
