    string s = @"Re:_=C8SOB_Poji=9A=9Dovna";
    string[] sArr = s.Split('=');
    List<string> temp = new List<string>();
    
    bool bGetTwo = false;
    
    if (s[0] == '=')
    {
        bGetTwo = true;
    }
    
    foreach (var str in sArr)
    {
        if (bGetTwo)
        {
            temp.Add(str.Substring(0, Math.Min(str.Length, 2)));
        }
    
        bGetTwo = true;
                    
        if (str.Length > 2)
        {
            string subStr = str.Substring(2, str.Length-2);
            foreach (var c in subStr.ToCharArray())
            {
                temp.Add(c.ToString());
            }                    
        }                
    }
    sArr = temp.ToArray();
