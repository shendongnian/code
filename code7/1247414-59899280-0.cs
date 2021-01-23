c#
public static IQueryable<IGrouping<TKey, TElement>> GroupByProps<TElement, TKey>(this IQueryable<TElement> self, TKey model, params string[] propNames)
{
    var modelType = model.GetType();
    var props = modelType.GetProperties();
    var modelCtor = modelType.GetConstructor(props.Select(t => t.PropertyType).ToArray());
    return self.GroupByProps(model, modelCtor, props, propNames);
}
public static IQueryable<IGrouping<TKey, TElement>> GroupByProps<TElement, TKey>(this IQueryable<TElement> self, TKey model, ConstructorInfo modelCtor, PropertyInfo[] props, params string[] propNames)
{
    var parameter = Expression.Parameter(typeof(TElement), "r");
    var propExpressions = props
        .Select(p =>
        {
            Expression value;
            if (propNames.Contains(p.Name))
                value = Expression.PropertyOrField(parameter, p.Name);
            else
                value = Expression.Convert(Expression.Constant(null, typeof(object)), p.PropertyType);
            return value;
        })
        .ToArray();
    var n = Expression.New(
        modelCtor,
        propExpressions,
        props
    );
    var expr = Expression.Lambda<Func<TElement, TKey>>(n, parameter);
    return self.GroupBy(expr);
}
I implemented two overloads in case you want to cash the constructor and properties to avoid reflection each time it's called. Use like this:
c#
//Class with properties that you want to group by
class Record
{
    public string Test { get; set; }
    public int? Hallo { get; set; }
    public DateTime? Prop { get; set; }
    public string PropertyWhichYouNeverWantToGroupBy { get; set; }
}
//usage
IQueryable<Record> queryable = ...; //the queryable
var grouped = queryable.GroupByProps(new
{
    Test = (string)null,        //put all properties that you might want to group by here
    Hallo = (int?)null,
    Prop = (DateTime?)null
}, nameof(Record.Test), nameof(Record.Prop));   //This will group by Test and Prop but not by Hallo
//Or to cash constructor and props
var anonymous = new
{
    Test = (string)null,        //put all properties that you might want to group by here
    Hallo = (int?)null,
    Prop = (DateTime?)null
};
var type = anonymous.GetType();
var constructor = type.GetConstructor(new[]
{
    typeof(string),             //Put all property types of your anonymous object here 
    typeof(int?),
    typeof(DateTime?)
});
var props = type.GetProperties();
//You need to keep constructor and props and maybe anonymous 
//Then call without reflection overhead
queryable.GroupByProps(anonymous, constructor, props, nameof(Record.Test), nameof(Record.Prop));
The anonymous object that you will receive as TKey will have only the Keys that you used for grouping (namely in this example "Test" and "Prop") populated, the other ones will be null.  
