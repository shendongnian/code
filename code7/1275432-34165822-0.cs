                    if (wordEnd == input.Length || input[wordEnd] == ' ')
                    {
                        indexE = wordEnd - 1;
                        while (indexS < wordEnd)
                        {
                            newStr[indexS] = input[indexE];
                            indexS++;
                            indexE--;
                        }
                        if (wordEnd < input.Length)
                        {
                            newStr[indexS] = ' ';
                            indexS++;
                        }
                    }
