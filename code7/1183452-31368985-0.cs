    List<Type2> GetOrderedType2List()    
    {
        ...
        return type2List.OrderBy(type2 =>
        {
            decimal orderValue;
            if (type2.Type1 == null)
                orderValue = 0;
            else if (type2.Type1.Value < 0)
                orderValue = Math.Abs(type2.Type1.Value);
            else
                orderValue = type2.Type1.Value;
            return orderValue;
        }).ToList();
    }
