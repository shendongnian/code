    public static class QueryableExtension
    {
        public static IEnumerable<SelectListItem> GetTable<T>(this IQueryable<T> source)
        {
            KeyValuePair<PropertyInfo, PropertyInfo> sourceDestPropMap1
                                            = new KeyValuePair<PropertyInfo, PropertyInfo>(
                                                typeof(SelectListItem).GetProperty("Text"), // Text prop of selected item
                                                     typeof(T).GetProperty("Name") // Name prop of T class
                                                     ); 
            KeyValuePair<PropertyInfo, PropertyInfo> sourceDestPropMap2
                                            = new KeyValuePair<PropertyInfo, PropertyInfo>(
                                                     typeof(SelectListItem).GetProperty("Value"), // Value prop of Selected Item
                                                     typeof(T).GetProperty("Id")); // Id prop from T class
            var name = "item";
            // -> declare Lambda parameter 'item' of type T i.e. Class1, Class2 etc.
            var paramExpr = Expression.Parameter(typeof(T), name);
            // -> Text = item.Id
            var propVal = Expression.Property(paramExpr, sourceDestPropMap2.Value);
            // -> Text = item.Id.ToString()
            var expression = Expression.Call(propVal, typeof(object).GetMethod("ToString"));
            // -> item => new SelectedListItem(Text = item.Name, Value = item.Id.Tostring());
            var projection = Expression.Lambda<Func<T, SelectListItem>>(
                                  Expression.MemberInit(
                                    Expression.New(typeof(SelectListItem)),
                                    new[] {
                                       Expression.Bind(sourceDestPropMap1.Key, Expression.Property(paramExpr, sourceDestPropMap1.Value)),
                                       Expression.Bind(sourceDestPropMap2.Key, expression)
                                    }
                                  ), paramExpr);
       // -> Class1.Select(item => new SelectedListItem(Text = item.Name, Value = item.Id.Tostring()).ToList()
            return source.Select(projection).ToList();
        }
    }
