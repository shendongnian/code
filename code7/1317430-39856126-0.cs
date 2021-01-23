    private static Word.WdListNumberStyle GetListType(Word.Range sentence)
    {
        foreach (Word.ListLevel lvl in sentence.ListFormat.ListTemplate.ListLevels)
        {
            return lvl.NumberStyle;
        }
    }
