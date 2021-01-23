    public static class IQueryableExtensions
    {
            public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortName, string sortOrder)
            {
                if (string.IsNullOrEmpty(sortName)) return query;
                var retQuery = query;
                var propGroup = sortName.Split(',');
    
                for (int k = 0; k < propGroup.Length; k++)
                {
                    var typeOfProp = typeof(T);
                    var sortField = propGroup[k];
                    var currentOrder = GetOrderMethod(sortOrder, k);
                    var param = Expression.Parameter(typeof(T), "o");
                    var props = sortField.Split('.');
                    Expression propertyAccess = param;
                    var i = 0;
                    do
                    {
                        var property = ReflectionTypePropertyCache<T>.GetProperty(props[i]);
                        if (property == null) throw new Exception("property not found :" + sortName);
                        typeOfProp = property.PropertyType;
                        propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                        i++;
                    } while (i < props.Length);
    
                    var orderByExp = Expression.Lambda(propertyAccess, param);
                    var resultExp = Expression.Call(typeof(Queryable),
                            currentOrder,
                            new[] { typeof(T), typeOfProp },
                            retQuery.Expression,
                            Expression.Quote(orderByExp));
                    retQuery = retQuery.Provider.CreateQuery<T>(resultExp);
                }
                return retQuery;
            }
    
            private static string GetOrderMethod(string sortOrder, int index)
            {
                const string ASC = "OrderBy";
                const string DESC = "OrderByDescending";
                const string THENASC = "ThenBy";
                const string THENDESC = "ThenByDescending";
                string AscVar, DescVar;
                if (index == 0)
                {
                    AscVar = ASC;
                    DescVar = DESC;
                }
                else
                {
                    AscVar = THENASC;
                    DescVar = THENDESC;
                }
    
                if (string.IsNullOrEmpty(sortOrder)) return AscVar;
                var orderArr = sortOrder.Split(',');
                if (index >= orderArr.Length) return AscVar;
                if (orderArr[index].ToLower() == "desc") return DescVar;
                return AscVar;
            }
    }
