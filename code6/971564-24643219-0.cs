    public void loadDataWithID(string _filterID)
    {
        using (var context = new Context())
        {
            var query = (from o in Order
                         join p in Products on o.ProductID equals p.ProductID
                         where o.OrderId==_filterID
                         select o);
            SourceList.Clear();
            SourceList.AddRange(query.ToList());
        ...
     }    
