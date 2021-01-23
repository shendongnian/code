    public void CheckLine(String line, List<IValidator> rules)
    {
        foreach (IValidator v in rules)
        {
            if (v.IsValid(line))
            {
               // it works
            }
            else
            {
               // do something when bad
            }
        }
    }
