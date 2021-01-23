    public Chain Get(string chainNumber)
    {
        var chain = session.Query<Chain>()
                        .Where(chain => chain.ChainNumber == chainNumber)
                        .Fetch(chain => chain.Steps)
                        .Single();
        if (chain == null)
        {
            throw new ObjectNotFoundException(
                string.Format("Chain not found for number: {0}.", chainNumber));
        }
        return chain;
    }
