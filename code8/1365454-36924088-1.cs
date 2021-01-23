    MyVisitor visitor = new MyVisitor();
    visitor.Visit(query.Expression);
    if (visitor.HasOrderBy)
    {
        //..
    }
    else
    {
        //..
    }
