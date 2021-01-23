            string input = ".....";
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            foreach (char c in input.ToLower())
            {
                if ((int)c < 97 || (int)c > 122)
                {
                    if (c == ' ' || c == ',' || c == ':' || c == ';')
                    {
                        charDict[' ']++;
                    }
                } else {
                    charDict[c]++;
                }
            }
