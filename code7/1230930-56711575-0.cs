    public bool IsAnagram(string s1,string s2)
    {
      if (s1.Length != s2.Length)
         return false;
      var s1Array = s1.ToLower().ToCharArray();
      var s2Array = s2.ToLower().ToCharArray();
    
      Array.Sort(s1Array);
      Array.Sort(s2Array);
    
      s1 = new string(s1Array);
      s2 = new string(s2Array);
      
      return s1 == s2;
    }
