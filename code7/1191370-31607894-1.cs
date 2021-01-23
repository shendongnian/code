    public double SumOfSomething 
    {
        get
        {
            return YourCollection.Sum(x => x.ItemSellingPrice);
        }
    }
    
