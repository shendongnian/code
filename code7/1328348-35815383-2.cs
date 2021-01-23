    public class Item
    {
        public Item(String str, Int32 @int)
        {
            this.StrValue = str;
            this.IntValue = @int;
        }
        public String StrValue { get; }
        public Int32 IntValue { get; }
        public override string ToString() => 
            $"{this.IntValue} = '{this.StrValue}'";
    }
    public static class ExpressionExtensions
    {
        public static Expression<Func<TItem, TResult>> Curry<TItem, TCurry, TResult>(
            this Expression<Func<TItem, TCurry, TResult>> function,
            TCurry value)
        {
            if (function == null)
                throw new ArgumentNullException(paramName: nameof(function));
            var itemParameter = Expression.Parameter(typeof(TItem));
            var valueConstant = Expression.Constant(value);
            return Expression.Lambda<Func<TItem, TResult>>(
                Expression.Invoke(
                    function,
                    new Expression[]
                    {
                        itemParameter,
                        valueConstant
                    }),
                new[] { itemParameter });
        }
    }
...
    var items = new[]
    {
        new Item("one", 1),
        new Item("two", 2),
        new Item("two again", 2),
    };
    Expression<Func<Item, Int32, Boolean>> predicate = (item, intValue) =>
        item.IntValue == intValue;
                
    var curriedPredicate = predicate.Curry(2);
    var filtered = items
        .AsQueryable<Item>()
        .Where(curriedPredicate)
        .ToArray();
    foreach (var item in filtered)
    {
        Console.WriteLine(item);
    }
