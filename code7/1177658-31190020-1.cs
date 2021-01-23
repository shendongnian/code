       public static TResult AddIfNotExists<T,TResult>(this DbSet<T> dbSet,  
                                                       T entity, 
                                                       Expression<Func<T, bool>> predicate,
                                                       Expression<Func<T, TResult>> columns  
                                                      ) where T : class, new()
       {
           if (predicate==null || columns==null)
               throw new Exception();
           //Find if already exist the entity and select its key column(s)
           var result =  dbSet.Where(predicate).Select(columns).FirstOrDefault();
        
           //the result could be a reference type (string or anonymous type) or a value type
           if (result!=null && !result.Equals(default(TResult)))
               return result;
           var newElement = dbSet.Add(entity);
           //Compile the Expresion to get the Func
           var func = columns.Compile();
           //To select the new element key(s), add the element to an array (or List) to apply the Select method and get the keys
           var r = new[]{newElement};
           return r.Select(func).FirstOrDefault();
       }
