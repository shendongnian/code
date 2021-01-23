    string s = "[A] == [B] * 10 - FUNCTION([C], STRING_EXPRESSION, FUNCTION([D], [C],[E])), FUNCTION([C], [X]), 100";
      List<string> splitted = new List<string>();
      int beginPos = 0;
      for (int i=1; i < s.Length; i++)
      {
        if (s[i] == ',' && s[i-1] == ')')// && i!=beginPos)
        {
          splitted.Add(s.Substring(beginPos, i-beginPos));
          i++;
          beginPos = i;
        }
      }
      if(beginPos < s.Length)
        splitted.Add(s.Substring(beginPos, s.Length-beginPos));
