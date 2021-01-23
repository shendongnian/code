    public decimal Sum(Func<ml_doc, bool> predicate, Func<ml_doc, decimal> sumColumn)
    {
        try
        {
            using (dbEnteties = new Entities(Connection.CustomEntityConnection))
            {
                dbEnteties.ContextOptions.LazyLoadingEnabled = true;
                var dbe = dbEnteties.ml_doc;
                return dbe.Where(predicate).Sum(sumColumn);
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
