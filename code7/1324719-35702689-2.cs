    public static bool IdenticalValues<T>(this List<Product> matchedProducts, Func<Product, T> matchExpression)
    {
        var itemToMatch = matchedProducts.First();
        if (matchedProducts.All(p => matchExpression(p) == matchExpression(itemToMatch)))
            return true;
        else
            return false;
    }
