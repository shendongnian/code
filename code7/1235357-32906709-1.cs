    public IEnumerable<string> GetLabels()
    {
        for (char l = 'a'; l < 'z'; l++)
        {
            for (int d = 0; d < 99; d++)
            {
                yield return string.Format("{0}{1:D2}", l, d);
            }
        }    
    }
