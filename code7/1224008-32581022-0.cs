    IEnumerable<FruitResult> q;
    if (!string.IsNullOrEmpty(condition))
    {
        q = from f in db.Fruits
            join a in db.Attributes
            on f.ID equals a.Fruits_ID
            where fa.AttributeValue.Contains(conditon)
            select FruitResult
            {
                // ...
            }
    }
    else
    {
        q = Enumberable.Empty<FruitResult>();
    }
