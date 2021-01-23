        public Boolean ContainsErrorOrExceptionExcept(string input, string[] excludedKeywords)
        {
            if (input.Contains("error") || input.Contains("exception"))
            {
                foreach (string x in excludedKeywords)
                {
                    if (input.Contains(x))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }
