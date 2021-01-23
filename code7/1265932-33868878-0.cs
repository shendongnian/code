    List<string> Result = new List<string>();
    
    void GenerateResult(string Intermediate, int Position)
    {
        if (Position == Words.Count() - 1) // base case, nothing to append
        {
            Result.Add(Intermadiate);
        }
        else
        {
            GenerateResult( Intermediate + " ", Position + 1 ); // space case
            GenerateResult( Intermediate + "-", Position + 1 ); // hyphen case
        }
    }
