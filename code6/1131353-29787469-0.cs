                            string code1 = "&#55357";
                            string code2 = "&#56835";
                            ulong numbericCode1 = ulong.Parse(code1.Substring(2));
                            ulong numbericCode2 = ulong.Parse(code2.Substring(2));
                            string hexCode = (numbericCode1 + numbericCode2).ToString("x5");​
