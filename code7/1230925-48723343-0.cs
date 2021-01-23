    public bool Anagram(string s , string p)
    {
        char[] dS = s.ToCharArray();
        char[] dP = p.ToCharArray();
        Array.Sort(dS);
        Array.Sort(dP);
        string rS = new string(dS);
        string rP = new string(dP);
        return rS == rP;
        
    }
   
