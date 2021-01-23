     string word = "hi"; ;
                    char[] wordArray = word.ToCharArray();
                    char[] revWordArray = wordArray.Reverse().ToArray();
                    int count = 0;
                    for (int i1 = 0; i1 < wordArray.Length; i1++)
                    {
                        if (wordArray[i1] == revWordArray[i1])
                        {
                            count++;
                        }
                    }
                    if (count == wordArray.Length)
                    {
                        bool a = true;
                    }
