    public void ReverseWords()
    {
        int wordEnd = 0, indexS = 0, indexE = 0;
        char[] newStr = new char[input.Length];
        while (wordEnd <= input.Length) //Needed to use <=
        {
            if (wordEnd < input.Length && input[wordEnd] != ' ')
            {
                wordEnd++;
            }
            else
            {
                //Reversed the conditional checks as the second check 
                //is an overflow with the last word
                if (wordEnd == input.Length || input[wordEnd] == ' ')
                {
                    indexE = wordEnd - 1;
                    while (indexS < wordEnd)
                    {
                        newStr[indexS] = input[indexE];
                        indexS++;
                        indexE--;
                    }
                    //Added condition to not add a space after the last word
                    if(wordEnd != input.Length)
                        newStr[indexS] = ' ';
                    indexS++;
                }
                wordEnd++;
            }
        }
        string nStr = new string(newStr);
        Console.WriteLine(nStr);
    }
    
