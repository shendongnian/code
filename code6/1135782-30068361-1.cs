    public static class GroupByExtensions
    {
        public static IEnumerable<IGrouping<object[], TValue>> GroupByKeys<TValue>(this IEnumerable<TValue> values, IEnumerable<string> keys)
        {
            var properties = MembersProvider.GetProperties(typeof(TValue), keys.ToArray());
            var comparer = new ArrayEqualityComparer<object>();
    
    
            // jamespconnor's string as key approch - off course it will need to return IEnumerable<IGrouping<string, TValue>> 
            /*return values.GroupBy(v => getters.Aggregate(
                "",
                (acc, getter) => string.Format(
                    "{0}-{1}",
                    acc,
                    getter.Invoke(v, null).ToString()
                    )
                )
            );*/
    
            //objects array as key approch 
            return values.GroupBy(v => properties.Select(property => property.GetValue(v, null)).ToArray(), comparer);
        }
    
    }
