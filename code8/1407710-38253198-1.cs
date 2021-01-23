        /// <summary>
        /// Recursively detaches item and sub-items from EF. Assumes that all sub-objects are properties (not fields).
        /// </summary>
        /// <param name="item">The item to detach</param>
        /// <param name="recursionDepth">Number of levels to go before stopping. object.Property is 1, object.Property.SubProperty is 2, and so on.</param>
        public static void DetachAll(this DbContext db, object item, int recursionDepth = 3)
        {
            //Exit if no remaining recursion depth
            if (recursionDepth <= 0) return;
            //detach this object
            db.Entry(item).State = EntityState.Detached;
            //get reflection data for all the properties we mean to detach
            Type t = item.GetType();
            var properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                              .Where(p => p.GetSetMethod()?.IsPublic == true)  //get only properties we can set                              
                              .Where(p => p.PropertyType.IsClass)              //only classes can be EF objects
                              .Where(p => p.PropertyType != typeof(string))    //oh, strings. What a pain.
                              .Where(p => p.GetValue(item) != null);           //only get set properties
            //if we're recursing, we'll check here to make sure we should keep going
            if (properties.Count() == 0) return;
            foreach (var p in properties)
            {
                //handle generics
                if (p.PropertyType.IsGenericType)
                {
                    //assume its Enumerable. More logic can be built here if that's not true.
                    IEnumerable collection = (IEnumerable)p.GetValue(item);
                    foreach (var obj in collection)
                    {
                        db.Entry(obj).State = EntityState.Detached;
                        DetachAll(db, obj, recursionDepth - 1);
                    }
                }
                else
                {
                    var obj = p.GetValue(item);
                    db.Entry(obj).State = EntityState.Detached;
                    DetachAll(db, obj, recursionDepth - 1);
                }
            }
        }
