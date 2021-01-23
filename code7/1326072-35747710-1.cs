    public string AverageRate
    {
        get
        {
            using (var dbContext = new Context()) //create a new Context or use a Global Context instead
            {
                return dbContext.tblRating.Where(r => r.CompanyId == Id).Average(r => r.Rate).ToString();
            }
        }
    }
