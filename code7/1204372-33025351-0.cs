    // <summary>
            // Functions takes the Large text and split the string according to the maximum length of the string per line.
            // </summary>
            // <param name="strData">String Data</param>
            // <param name="intMaxSize">Maximum Size of the row</param>
            // <returns></returns>
            public static List<string> GetLines(string strData, int intMaxSize)
            {
                List<string> strReturn = new List<string>();
                string[] strLineSplited = strData.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                for (int intNoOfLine = 0; intNoOfLine < strLineSplited.Length; intNoOfLine++)
                {
                    List<KeyValuePair<char, int>> listOfChar = new List<KeyValuePair<char, int>>();
                    string strValue = strLineSplited[intNoOfLine];
                    StringBuilder sbSingleLine = new StringBuilder();
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        char[] charArr = strValue.ToCharArray();
                        int intCharCount = 0;
                        byte[] bascii = Encoding.ASCII.GetBytes(strValue);
                        for (int intCounter = 0; intCounter < bascii.Length; intCounter++)
                        {
                            int intASCIICode = bascii[intCounter];
                            if (intASCIICode >= 32 && intASCIICode <= 62)
                            {
                                listOfChar.Add(new KeyValuePair<char, int>(charArr[intCounter], 1));
                            }
                            else if (intASCIICode >= 65 && intASCIICode <= 122)
                            {
                                listOfChar.Add(new KeyValuePair<char, int>(charArr[intCounter], 1));
                            }
                            else
                            {
                                listOfChar.Add(new KeyValuePair<char, int>(charArr[intCounter], 2));
                            }
                        }
                        bool bFlag = true;
                        foreach (var charValue in listOfChar)
                        {
                            intCharCount += Convert.ToInt32(charValue.Value);
                            if (intCharCount < intMaxSize)
                            {
                                sbSingleLine.Append(charValue.Key);
                                bFlag = true;
                            }
                            else
                            {
                                sbSingleLine.Append(charValue.Key);
                                strReturn.Add(sbSingleLine.ToString());
                                sbSingleLine.Length = 0;
                                sbSingleLine.Capacity = 0;
                                intCharCount = 0;
                                bFlag = false;
                            }
                        }
                        if (intCharCount < intMaxSize && bFlag)
                        {
                            strReturn.Add(sbSingleLine.ToString());
                        }
                    }
                    else
                    {
                        strReturn.Add(sbSingleLine.ToString());
                    }
                }
                return strReturn;
            }
