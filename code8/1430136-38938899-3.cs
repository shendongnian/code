            string input = "test string here";
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            foreach(char c in input.ToLower()) {
                if(c < 97 || c > 122) {
                    if(c == ' ' || c == ',' || c == ':' || c == ';') {
                        charDict[' '] = (charDict.ContainsKey(' ')) ? charDict[' ']++ : 0;
                    }
                } else {
                    charDict[c] = (charDict.ContainsKey(c)) ? charDict[c]++ : 0;
                }
            }
