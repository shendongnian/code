    string[] array = new string[] {"TODO 06:15PMJoin Michael", 
        "WakeUp", 
        "Going to schools"};
    string[] SplitArray(string[] array)
    {
        List<string> returnArray = new List<string>();
    
        foreach (string item in array)
        {
            int index = GetIndex(item);
            if (index >= 0)
            {
                string s1 = item.Substring(0, index + 2);
                string s2 = item.Substring(index + 2);
                returnArray.Add(s1);
                returnArray.Add(s2);
            }
            else
            {
                returnArray.Add(item);
            }
        }
    
        return returnArray.ToArray();
    }
    int GetIndex(string s)
    {
        int index = GetIndexOf(s, "AM");
    
        if (index == -1)
        {
            index = GetIndexOf(s, "PM");
        }
    
        return index;
    }
    
    int GetIndexOf(string s, string delim)
    {
        int index = -1;
        
        int tempIndex = 0;
        do
        {
            tempIndex = s.IndexOf(delim, tempIndex);
            if (tempIndex > 0)
            {
                if (char.IsDigit(s[tempIndex-1]))
                {
                    index = tempIndex;
                    break;
                }
            }
        }
        while(tempIndex >= 0);
    
        return index;
    }
