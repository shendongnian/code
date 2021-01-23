    SortedDictionary<string, string> Dates = new SortedDictionary<string, string>();
    Dates.Add("1", "10/06/2015WD 2  ");
    Dates.Add("2", "10/07/2015HD 1");
    Dates.Add("3", "10/08/2015WD 2 ");
    for(int i = 0; i < Dates.Count; i++)
     {
       string Key = Dates.ElementAt(i).Key;
       string CurrentValue = Dates.ElementAt(i).Value.Trim();
       string CurrentValueLastChar = CurrentValue.Substring(CurrentValue.Length - 1, 1);
       if (i - 1 != -1 && i + 1 < Dates.Count)
        {
          string PreviousValue = Dates.ElementAt(i - 1).Value.Trim();
          string NextValue = Dates.ElementAt(i + 1).Value.Trim();
          string PreviousValueLastChar = PreviousValue.Substring(PreviousValue.Length - 1, 1);
          string NextValueLastChar = NextValue.Substring(NextValue.Length - 1, 1);
          if (PreviousValueLastChar == NextValueLastChar)
               Dates[Key] = (Dates[Key].Remove(Dates[Key].Length - 1)) + PreviousValueLastChar;
    
        }                
                                
     }
