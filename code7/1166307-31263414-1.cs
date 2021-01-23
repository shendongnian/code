        public Expression<Func<T, Boolean>> GetWhereFunc<T>(List<WhereCondition> searchFieldList,T item)
        {
            try
            {
                if (searchFieldList == null || searchFieldList.Count == 0)
                {
                    return null;
                }
                ParameterExpression pe = Expression.Parameter(item.GetType(), "c");
                
                //ParameterExpression pe = Expression.Parameter(typeof(object), "c");
                Type itemType = item.GetType();
                //combine them with and 1=1 Like no expression
                Expression combined = null;
                Type tempPropType;
                if (searchFieldList != null)
                {
                    foreach (WhereCondition fieldItem in searchFieldList)
                    {
                        if (string.IsNullOrEmpty(fieldItem.Value))
                            continue;
                        if (!string.IsNullOrEmpty(fieldItem.GridTblName))
                            continue;
                        //Expression for accessing Fields name property
                        Expression columnNameProperty = Expression.Property(pe, fieldItem.ColumName);
                        //the name constant to match 
                        Expression columnValue = null;
                        tempPropType = itemType.GetProperty(fieldItem.ColumName).PropertyType;
                        if (tempPropType == typeof(DateTime) || tempPropType == typeof(DateTime?))
                        {
                            if (string.IsNullOrEmpty(fieldItem.Value))
                            {
                            }
                            else
                            {
                                DateTime tempdate = DateTime.Parse(fieldItem.Value);
                                TimeZone zoneclient = TimeZone.CurrentTimeZone;
                                TimeSpan spclient = zoneclient.GetUtcOffset(tempdate);
                                tempdate = tempdate.AddMinutes(-1 * spclient.TotalMinutes);
                                fieldItem.Value = tempdate.ToString();
                            }
                        }
                        if (tempPropType == typeof(Guid) || tempPropType == typeof(Guid?))
                        {
                            if (string.IsNullOrEmpty(fieldItem.Value))
                            {
                                columnValue = Expression.Constant(null);
                            }
                            else
                            {
                                if (tempPropType == typeof(Guid?))
                                {
                                    columnValue = Expression.Constant((Guid?)Guid.Parse(fieldItem.Value), typeof(Guid?));
                                }
                                else
                                {
                                    columnValue = Expression.Constant(Guid.Parse(fieldItem.Value));
                                }
                            }
                        }
                        else if (tempPropType.IsGenericType && tempPropType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            if (string.IsNullOrEmpty(fieldItem.Value))
                            {
                                columnValue = Expression.Constant(null);
                            }
                            else
                            {
                          
                                columnValue = Expression.Constant(Convert.ChangeType(fieldItem.Value, tempPropType.GetGenericArguments()[0])
                                    , tempPropType);
                            }
                        }
                        else
                        {
                            columnValue = Expression.Constant(Convert.ChangeType(fieldItem.Value, tempPropType));
                        }
                        Expression e1 = null;
                        MethodInfo method;
                        switch (fieldItem.Cond)
                        {
                            case Condetion.Equal:
                                e1 = Expression.Equal(columnNameProperty, columnValue);
                                break;
                            case Condetion.Greater:
                                e1 = Expression.GreaterThan(columnNameProperty, columnValue);
                                break;
                            case Condetion.GreaterOrEqual:
                                e1 = Expression.GreaterThanOrEqual(columnNameProperty, columnValue);
                                break;
                            case Condetion.Lower:
                                e1 = Expression.LessThan(columnNameProperty, columnValue);
                                break;
                            case Condetion.LowerOrEqual:
                                e1 = Expression.LessThanOrEqual(columnNameProperty, columnValue);
                                break;
                            case Condetion.NotEqual:
                                e1 = Expression.NotEqual(columnNameProperty, columnValue);
                                break;
                            case Condetion.Contaiens:
                                if (fieldItem.IsContaien)
                                {
                                    Type tt = fieldItem.Values.GetType();
                                    
                                    if (tt == typeof(List<dynamic>))
                                    {
                                        IEnumerable<dynamic> val = fieldItem.Values.Cast<dynamic>().ToList();
                                        var someValueContain = Expression.Constant(val, val.GetType());
                                        var convertExpression = Expression.Convert(columnNameProperty, typeof(object));
                                        e1 = Expression.Call(someValueContain, "Contains", new Type[] { }, convertExpression);
                                    }
                                    else
                                    {
                                        var mval = fieldItem.Values.AsQueryable().Cast<dynamic>();
                                        var someValueContain = Expression.Constant(mval, mval.GetType());
                                        var convertExpression = Expression.Convert(columnNameProperty, typeof(object));
                                        e1 = Expression.Call((
                                            ((Expression<Func<bool>>)
                                            (() => Queryable.Contains(default(IQueryable<dynamic>), default(object))))
                                            .Body as MethodCallExpression).Method,
                                            someValueContain,
                                            convertExpression);
                                    }
                                    
                                }
                                else
                                {
                                    method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                                    var someValueContain = Expression.Constant(fieldItem.Value, columnValue.Type);
                                    e1 = Expression.Call(columnNameProperty, method, someValueContain);
                                }
                                break;
                            case Condetion.StartWith:
                                method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                                var someValueStartWith = Expression.Constant(fieldItem.Value, columnValue.Type);
                                e1 = Expression.Call(columnNameProperty, method, someValueStartWith);
                                break;
                            case Condetion.EndWith:
                                method = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                                var someValueEndWith = Expression.Constant(fieldItem.Value, columnValue.Type);
                                e1 = Expression.Call(columnNameProperty, method, someValueEndWith);
                                break;
                            case Condetion.NotContaiens:
                                if (fieldItem.IsContaien)
                                {
                                    Type tt = fieldItem.Values.GetType();
                                    if (tt == typeof(List<dynamic>))
                                    {
                                        IEnumerable<dynamic> val = fieldItem.Values.Cast<dynamic>().ToList();
                                        var someValueContain = Expression.Constant(val, val.GetType());
                                        var convertExpression = Expression.Convert(columnNameProperty, typeof(object));
                                        e1 = Expression.Call(someValueContain, "Contains", new Type[] { }, convertExpression);
                                        e1 = Expression.Not(e1);
                                    }
                                    else
                                    {
                                        var mval = fieldItem.Values.AsQueryable().Cast<dynamic>();
                                        var someValueContain = Expression.Constant(mval, mval.GetType());
                                        var convertExpression = Expression.Convert(columnNameProperty, typeof(object));
                                        e1 = Expression.Call((
                                            ((Expression<Func<bool>>)
                                            (() => Queryable.Contains(default(IQueryable<dynamic>), default(object))))
                                            .Body as MethodCallExpression).Method,
                                            someValueContain,
                                            convertExpression);
                                        e1 = Expression.Not(e1);
                                    }
                                }
                                else
                                {
                                    method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                                    var someValueContain = Expression.Constant(fieldItem.Value, columnValue.Type);
                                    e1 = Expression.Call(columnNameProperty, method, someValueContain);
                                    e1 = Expression.Not(e1);
                                }
                                break;
                        }
                        if (combined == null)
                        {
                            combined = e1;
                        }
                        else
                        {
                            combined = Expression.And(combined, e1);
                        }
                    }
                }
                if (combined == null)
                {
                    return null;
                }
                var mm = Expression.Lambda<Func<T, bool>>(combined, pe);
                
                return mm;//.Compile();
            }
            catch (Exception ex)
            {
                Logs.Log(ex);
                return null;
            }
        }
    public class WhereCondition
    {
        public string ColumName { set; get; }
        public string Value { set; get; }
        public Condetion Cond { set; get; }
        public string GridTblName { set; get; }
        public IEnumerable<dynamic> Values { set; get; }
        public bool IsContaien { set; get; }
        public WhereCondition(string columName, string value, Condetion cond)
        {
            ColumName = columName;
            Value = value;
            Cond = cond;
        }
        public WhereCondition()
        {
            ColumName = "";
            Value = "";
            Cond = Condetion.Equal;
        }
    }
    public enum Condetion { Equal, Greater, GreaterOrEqual, Lower, LowerOrEqual, NotEqual, Contaiens, NotContaiens, StartWith,EndWith }
