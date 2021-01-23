    class Result
    {
        public A ValueA {get;set;}
        public IEnumerable<B> ValuesB {get;set;}
    }
    
    public IQueryable<Result> GetA(string name, string at1)
    {
        return Find(ar => ar.Name == name).Select(ar => new Result{ValueA = ar, ValuesB = ar.Otros.Where(oaa => oaa.At1 == at1)})
    }
