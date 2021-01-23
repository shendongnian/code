    public static bool IdenticalValues<T>(this List<Product> matchedProducts, Func<Product, T> matchExpression)
    {
        var itemToMatch = matchedProducts.First();
        if (matchedProducts.All(p => EqualityComparer<T>.Default.Equals(matchExpression(p), matchExpression(itemToMatch))))
            return true;
        else
            return false;
    }
