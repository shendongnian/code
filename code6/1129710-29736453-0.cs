            private string SubCypher(string input, string charsToSub)
            {
                //Each letter in the word will be replaced by a letter from the corresponding position 
                //in a substitution alphabet. For this lab use this substitution alphabet: zeroabcdfghijklmnpqstuvwxy. 
                //Example: disk would become ofqh.
                input = input.ToLower();
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                string subAlpha = "zeroabcdfghijklmnpqstuvwxy";
                string str1 = input;
                string subCypher = subAlpha;
                string output = "";
                for (int i = 0; i < input.Length; i++)
                {
                    string chr = input.Substring(i, 1);
                    int index  = alphabet.IndexOf(chr);
                    if (index >= 0)
                    {
                        output += subAlpha[index];
                    }
                    else
                    {
                        //character is not a letter
                        output += chr;
                    }
                }
                return output;
            }​
