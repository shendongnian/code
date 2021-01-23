    public string VersionNumberCompareString(string versionNumber, int MaxWidth1=3, int MaxWidth2=7,int MaxIndivParts=5){
        string result = null;
    
        int posMinus = versionNumber.IndexOf('-');
        string part1 = versionNumber.Substring(0, posMinus);
        string part2 = versionNumber.Substring(posMinus+1);
    
        var integerValues=part1.Split('.');
        result = integerValues[0].PadLeft(MaxWidth1, '0');
        result += integerValues[1].PadLeft(MaxWidth1, '0');
        result += integerValues[2].PadLeft(MaxWidth1, '0');
    
        var alphaValues = part2.Split('.');
        for (int i = 0; i < MaxIndivParts;i++ ) {
            if (i <= alphaValues.GetUpperBound(0)) {
                var s = alphaValues[i];
                int casted;
                if (int.TryParse(s, out casted)) //if int: treat as number
                    result += casted.ToString().PadLeft(MaxWidth2, '0');
                else //treat as string
                    result += s.PadRight(MaxWidth2, ' ');
        }
        else
            result += new string(' ', MaxWidth2);
    }
    return result;    }
