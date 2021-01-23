    class Program
    {
        static void Main(string[] args)
        {
            using (var x = new DB01Entities ())
            {
                Type myType = typeof(Angajati);
                
                var setMethod = typeof(DB01Entities).GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Where (a => a.Name == "Set" && a.IsGenericMethod).First ().GetGenericMethodDefinition ();
                var mySet = setMethod.MakeGenericMethod(myType);
                var realSet = mySet.Invoke(x, null);
                var param1 = Expression.Parameter(myType, "param1");
                
                var propertyExpresion = Expression.Property(param1, "Id");
                var idExpresssion = Expression.Constant(1);
                var body = Expression.Equal(propertyExpresion, idExpresssion);
                var lambda = Expression.Lambda(body, param1);
                var genericTypeCaster = typeof(Program).GetMethod("Caster", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetGenericMethodDefinition();
                var effectiveMethod = genericTypeCaster.MakeGenericMethod(myType);
                var filteredQueryable = effectiveMethod.Invoke(null, new Object[] {realSet, lambda });
            }
        }
        private static IQueryable<T> Caster <T> (DbSet<T> theSet, Expression whereCondition) where T : class
        {
            return theSet.Where(whereCondition as Expression<Func<T, bool>>);
        }
    }
