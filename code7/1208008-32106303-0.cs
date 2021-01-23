    public Expression<Func<Foobar, double>> FirstAmountExpr
    {
        get
        {
            if (ShouldGetFirstAmount)
            {
                return x => x.AmountOne;
            }
            else
            {
                return x => x.AmountTwo;
            }
        }
    }
    
    public double GetFirstAmount()
    {
        return repository.Foobars.Select(FirstAmountExpr).First();
    }
