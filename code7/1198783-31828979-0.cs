    List<string> cellReferences = new List<string>();
    List<string> digits = new List<string>();
    String[] values  = {"A1","B1","C1","5"};
    
    foreach(string val in values)
    {
      if(Char.IsLetter(val[0]))
        cellReferences.Add(val);
      else
        digits.Add(val);
    }
