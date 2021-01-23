    using (ISession session = SessionFactory.OpenSession)
    {
        //IQuery query = session.CreateQuery("FROM Products");
        var query = session.CreateQuery("FROM Product"); // just Product
        // here again
        //IList<Products> pInfos = query.List<Products>();
        IList<Product> pInfos = query.List<Product>();
        ...
