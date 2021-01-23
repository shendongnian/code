    //Ideally we return something more specific eg, IEnumerable<Tokens>
    public IEnumerable<string> ParseEquation(IEnumerable<string> words)
    {
        foreach (var word in words)
        {
            if (IsOperator(word)) yield return ToOperator(word);
            else if (IsCode(word)) yield return ToCode(word);
            else ...;
        }
    }
