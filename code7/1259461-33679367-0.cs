    public string AutoUpdate(string _search)
    {
        System.Linq.Expressions.Expression<Func<Cantact, bool>> WhereClause = (d) => d.Cantact1 == _search;
        return FirstContact(WhereClause);
        // or
        //return FirstContact((d) => d.Cantact1 == _search));
    }
    public string FirstContact(Expression<Func<Cantact, bool>> WhereClause) 
    {
        using (var context = new Phone_BookEntities1()) 
        {
            //var query = context.Cantacts.FirstOrDefault(WhereClause);
            var query = context.Cantacts.Where(WhereClause).FirstOrDefault();            
            return (query == null) ? String.Empty : query ;
        }
    }
