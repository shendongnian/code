    class HasIntKey : RealmObject {
        public int UserKey { get; set; }
    }
    private void FindingManyMatches()
    {
        using (var theRealm = Realm.GetInstance ("TestingManyKeys.realm")) {
            theRealm.Write (() => {
                for (int i = 1; i < 10000; i++) {
                    var obj = theRealm.CreateObject<HasIntKey> ();
                    obj.UserKey = i;
                }
            });
            var allInts = theRealm.All<HasIntKey>();
            Console.WriteLine ($"Created {allInts.Count()} objects");
            // technique for how to search for many matches
            // use Expression Trees to dynamically build the LINQ statement
            // see https://msdn.microsoft.com/en-us/library/mt654267.aspx
            var idsToMatch = new[] {42,1003,400,57, 6009};
            ParameterExpression pe = Expression.Parameter (typeof(HasIntKey), "p");
            // allInts.Where (p => p.UserKey == idsToMatch[0] || p.UserKey == idsToMatch[1]...);
            Expression chainedByOr = null;
            // left side of the == will be the same for each clause we add in the loop
            Expression left = Expression.Property(pe, typeof(HasIntKey).GetProperty("UserKey"));  
            foreach (int anId in idsToMatch) {
                // Create an expression tree that represents the expression 'p.UserKey == idsToMatch[n]'.
                Expression right = Expression.Constant(anId);
                Expression anotherEqual = Expression.Equal(left, right);
                if (chainedByOr == null)
                    chainedByOr = anotherEqual;
                else 
                    chainedByOr = Expression.OrElse (chainedByOr, anotherEqual);
            }
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { allInts.ElementType },
                allInts.Expression,
                Expression.Lambda<Func<HasIntKey, bool>>(chainedByOr, new ParameterExpression[] { pe }));
            // Create an executable query from the expression tree.
            IQueryable<HasIntKey> results = allInts.Provider.CreateQuery<HasIntKey>(whereCallExpression);
            Console.WriteLine ($"Found {results.Count()} objects");
            // Enumerate the results.
            foreach (HasIntKey anObj in results)
                Console.WriteLine($"Found key {anObj.UserKey}");
        }
    }
