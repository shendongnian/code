    string str = "AB-C-D-EF-G-HI";
    string[] splitted = str.Split('-');
    
    List<string> finalList = new List<string>();
    
    string temp = "";
    
    for (int i = 0; i < splitted.Length; i++)
    {
        temp += splitted[i];
    }
    finalList.Add(temp);
    temp = "";
    
    for (int diff = 0; diff < splitted.Length-1; diff++)
    {
        for (int start = 1, limit = start + diff; limit < splitted.Length; start++, limit++)
        {
            int i = 0;
            while (i < start)
            {
                temp += splitted[i++];
            }
            while (i <= limit)
            {
                temp += "-";
                temp += splitted[i++];
            }
            while (i < splitted.Length)
            {
                temp += splitted[i++];
            }
            finalList.Add(temp);
            temp = "";
        }
    }
