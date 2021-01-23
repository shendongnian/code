    var WordsToRemove = new[] { "a", "is", "about", "above", "after", "again", "against", "all" };
    var Delimiters = ".,;: ()!?/";
    int LastIndex = 0;
    var NewDesc = "";
    for (int row = 0; row < dt.Rows.Count; row++)
    {
    for (int i = 0; i < dt[row]["Description"].Length; i++)
    {
      if (Delimiters.IndexOf(dt[row]["Description"][i]) >= 0)
      {
        var Word = dt[row]["Description"].Substring(LastIndex, i - LastIndex + 1);
        if (WordsToRemove.Contains(Word.Trim(Delimiters.ToCharArray())))
          NewDesc += dt[row]["Description"][i];
        else
          NewDesc += Word;
        LastIndex = i + 1;
      }
    }
    }
