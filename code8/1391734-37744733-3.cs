    var WordsToRemove = new[] { "a", "is", "about", "above", "after", "again", "against", "all" };
    var Delimiters = ".,;: ()!?/";
    int LastIndex = 0;
    var NewDesc = "";
    for (int row = 0; row < dt.Rows.Count; row++)
    {
      var Description = dt.Rows[row]["Description"].ToString();
    for (int i = 0; i < Description.Length; i++)
    {
      if (Delimiters.IndexOf(Description[i]) >= 0)
      {
        var Word = Description.Substring(LastIndex, i - LastIndex + 1);
        if (WordsToRemove.Contains(Word.Trim(Delimiters.ToCharArray())))
          NewDesc += Description[i];
        else
          NewDesc += Word;
        LastIndex = i + 1;
      }
    }
    }
