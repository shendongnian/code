    string[] stringFormat = new string[7] { "1H 34'", "4H 89'", "4H 89", "42 89", "4H 8H'", "345 t3", "4H 333'" };
                List<string> requiredFormattedStrings = new List<string>();
                foreach (var stringValue in stringFormat)
                {
                    string[] val = stringValue.Split(' ');
                    if ((val[0].Length == 2 && val[0].EndsWith("H")) && (val[1].Length == 3 && val[1].EndsWith("'")))
                    {
                        bool isNumber = Char.IsDigit(val[0], 0);
                        if (isNumber)
                        {
                            string secondString = val[1].Substring(0, 2);
                            bool isNumber2 = secondString.All(c => Char.IsDigit(c));
                            if(isNumber2)
                            {
                                requiredFormattedStrings.Add(stringValue);
                            }
                        }
                    }
                }
