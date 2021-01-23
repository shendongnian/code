            string input = "test string here";
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            foreach(char c in input.ToLower()) {
                if(c < 97 || c > 122) {
                    if(c == ' ' || c == ',' || c == ':' || c == ';') {
                        if(charDict.ContainsKey(' ')) {
                            charDict[' ']++;
                        } else {
                            charDict[' '] = 0;
                        }
                    }
                } else {
                    if(charDict.ContainsKey(c)) {
                        charDict[c]++;
                    } else {
                        charDict[c] = 0;
                    }
                }
            }
