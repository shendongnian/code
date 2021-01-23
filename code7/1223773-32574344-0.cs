    private List<Entity> GetData(DateTime? dateFrom, DateTime? dateTo)
    {
        IQueryable<Entity> query = ...; //Here reference your table
        if (dateFrom == null && dateTo == null)
        {
            query = query.Take(100);
        }
        else
        {
            DateTime dateToValue = dateTo ?? DateTime.Now;
            query = query.Where(x => x.Date <= dateToValue);
            if (dateFrom != null)
            {
                query = query.Where(x => x.Date >= dateFrom.Value);
            }
        }
        return query.ToList(); //This will actually execute the query. Here you can expand your query to select specific columns before executing ToList
    }
