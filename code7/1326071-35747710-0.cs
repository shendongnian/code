    public string AverageRate
    {
        get
        {
            using (var dbContext = new Context()) //create a new Context or use a Global Context instead
            {
                var totalRating = dbContext.tblRating.Where(r => r.CompanyId == Id).Sum(r => r.Rate);
                var countRating = dbContext.tblRating.Count(r => r.CompanyId == Id);
                return (totalRating / countRating).ToString();
            }
        }
    }
