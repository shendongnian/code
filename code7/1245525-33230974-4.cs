    private string removeOneParen(string input)
    {
        string output = "ERROR";
    
        int openingCount = 0;
        int closingCount = 0;
        bool firstOpening = true;
        int startI = -1;
        for (int i = 0; i < input.Length; i++)
        {
            string curBit = input.Substring(i, 1);
            if (curBit == "(")
            {
                openingCount = openingCount + 1;
                if (firstOpening)
                {
                    startI = i + 1;
                    firstOpening = false;
                }
            }
            else if (curBit == ")")
            {
                closingCount = closingCount + 1;
                if (openingCount == closingCount)
                {
                    if(startI > 0) output = input.Substring(0, startI - 1);
                    output = output + input.Substring(startI, i - startI);
                    if(i < input.Length - 1) output = output + input.Substring(i + 1);
                    break;
                }
            }
        }
    
        return output;
    }
