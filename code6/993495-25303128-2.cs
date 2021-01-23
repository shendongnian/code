    IEnumerable<string> ConcatEnumerablesRec(IEnumerable<IEnumerable<object>> enums)
    {            
        //base cases
        if(!enums.Any())
        {
            return Enumerable.Empty<string>();
        }
        if (enums.Count() == 1)
        {
            return enums.First().Select(o => o.ToString());
        }
        
        //recursively solve the problem
        return ConcatEnumerables(enums.First(), ConcatEnumerablesRec(enums.Skip(1));
    }
