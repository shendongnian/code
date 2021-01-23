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
...
    var items = new[]
    {
        new Item("one", 1),
        new Item("two", 2),
    };
    Expression<Func<Item, Int32, Boolean>> predicate = (item, intValue) =>
        item.IntValue == intValue;
    var value = 2;
    var itemParameter = Expression.Parameter(typeof(Item));
    var valueConstant = Expression.Constant(value);
    var curriedPredicate = Expression.Lambda<Func<Item, Boolean>>(
        Expression.Invoke(
            predicate,
            new Expression[]
            {
                itemParameter,
                valueConstant
            }),
        new[] { itemParameter });
    var filtered = items
        .AsQueryable<Item>()
        .Where(curriedPredicate)
        .ToArray();
    foreach (var item in filtered)
    {
        Console.WriteLine(item);
    }
