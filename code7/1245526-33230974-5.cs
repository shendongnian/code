    private string removeAllParen(string input)
    {
        string output = input;
        
        int openingCount = 0;
        int closingCount = 0;
        do
        {
            openingCount = output.Split('(').Length - 1;
            closingCount = output.Split(')').Length - 1;
            if (openingCount != closingCount || openingCount < 1 || closingCount < 1)
            {
                if (openingCount != closingCount) output = "ERROR";
                break;
            }
            output = removeOneParen(output);
        } while (true);
    
    
        return output;
    }
    
    private string removeOneParen(string input)
    {
        string output = input;
        int count = 0;
    
        bool error = false;
        int iIni = 0;
        int iEnd = output.Length - 1;
        while (count < 2)
        {
            count = count + 1;
            bool ended = false;
            if (count == 2)
            {
                iIni = output.Length - 1;
                iEnd = 0;
            }
            int i = iIni;
            while (!ended)
            {
                string curBit = output.Substring(i, 1);
                if (curBit == "(" || curBit == ")")
                {
                    if (count == 1 && curBit == "(" && i < output.Length - 2) output = output.Substring(i + 1);
                    else if (count == 2 && curBit == ")") output = output.Substring(0, i);
                    else error = true;
                    break;
                }
            }
            if (error) break;
        }
    
        if (error) output = "ERROR";
    
        return output;
    }
