    public IQueryable<T> AsDynamicQueryable<T>() where T : class
    {
        // ERROR!!! It should be Expression<Func<T, bool>>
        // GetPredicate<T>() is my method to get the predicate. You must
        // put here yours. IT must return an Expression<Func<T, bool>>
        Expression<Func<T, bool>> predicate = GetPredicate<T>(); // This is a Dynamically generated predicate 
        // ERROR!!! Don't EVER use AsQueryable(), unless you exactly know
        // what you are doing. In this example, your use of AsQueryable<>()
        // is hiding the fact that you are executing the Where() LOCALLY,
        // because it is a Where(this IEnumerable<>, Func<>) instead of
        // being a Where(this IQueryable<>, Expression<>)
        // If you want an IQueryable<>, put it in a IQueryable<> variable
        IQueryable<T> query = this.Set<T>().Where(predicate);
        var rootType = typeof(T);
        var innerType = GetAsDynamicQueryableInnerType<T>();
        // Same as before! Don't use .AsQueryable(). In this case, use 
        // IQueryable (non-generic). Note that in this case there was
        // no problem with yoru code, so AsQueryable() wasn't doing 
        // "damage"
        IQueryable innerExpression = this.Set(innerType);
        var paramOne = Expression.Parameter(rootType, "p1");
        var paramTwo = Expression.Parameter(innerType, "p2");
        // GetPrimaryKey() is my method to get the property to use.
        // it returns a string with the name of the property
        string primaryKeyRootType = GetPrimaryKey(rootType);
        var outerKeySelector = Expression.Property(paramOne, primaryKeyRootType); //'property_one' is a property of a first parameter which takes from the configuration
        var outerKeySelectorExpression = Expression.Lambda(outerKeySelector, paramOne); // (p1)=>p1.property_one
        // GetForeignKey() is my method to get the property to use.
        // it returns a string with the name of the property
        var foreignKeyInnerType = GetForeignKey(innerType, rootType);
        var innerKeySelector = Expression.Property(paramTwo, foreignKeyInnerType); //'property_two' is a property of a 2nd parameter which takes from the configuration
        var innerKeySelectorExpression = Expression.Lambda(innerKeySelector, paramTwo); // (p2)=>p2.property_two
        var resultSelector = Expression.Lambda(paramOne, paramOne, paramTwo); // (p1,p2)=>p1
        // Using outerKeySelector.Type as the type of the third parameter
        // here. 99% it is typeof(int), but why not make it more generic?
        var joinMethod = typeof(Queryable)
                            .GetMethods()
                            .First(m => m.Name == "Join" && m.GetParameters().Length == 5)
                            .MakeGenericMethod(rootType, innerType, outerKeySelector.Type, rootType);
        // Queryable.Join is static, so the first parameter must be null!
        // Then the parameters to pass to Queryable.Join are the ones you
        // where using in the 1st case.
        var newQuery = (IQueryable<T>)joinMethod.Invoke(
                                            null,
                                            new object[]
                                            { 
                                                query,
                                                innerExpression,
                                                outerKeySelectorExpression,
                                                innerKeySelectorExpression,
                                                resultSelector
                                            });
        return newQuery;
    }
