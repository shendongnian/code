     var t = o.GetType();
     var genericIComparableOfItself = t.GetInterfaces().Where(i => i.IsGenericType && 
                                                    i.GetGenericTypeDefinition().IsAssignableFrom(typeof(IComparable<>)) &&
                                                    i.GetGenericArguments().First() == t).FirstOrDefault();
     Func<object, int> compareTo = other => (int)comp.GetMethod("CompareTo", new Type[] { t }).Invoke(o, new object[] { other }); //yuck!
