    public string simplifyString(string sInput)
    {
        if (sInput.Length < 2)
        {
            return sInput;
        } 
    
        string sOutput = sInput[0].ToString(); //Add initial for string
        int iCount = 0;
    
        for (int i=1; i < sInput.Length; i++)
        {
            if (sInput[i] != sInput[iCount])
            {
                iCount++;
                sOutput += sInput[i].ToString();//add new char as string to the end of the string
            }
        }
        return sOutput;
    }
