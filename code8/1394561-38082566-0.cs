    //values to filter
    var values = new int[] { 1, 10, 46, 51, 58, 92, 105, 110 }.AsQueryable();
    var filters = new Expression<Func<int, bool>>[] {
        i => i % 2 == 0, // integer is even
        i => i > 50,     // integer is greater than 50
        i => i < 100     // integer is less than 100
    };
    var result = filters.Aggregate(values, (current, expression) => current.Where(expression));
    //result is { 58, 92 }
