    public class ABDTO<T,U> 
        {
            public T A { get; set; }
            public U B { get; set; }
        }
        public static class Helper
        {
            public static IQueryable<ABDTO<T,U>> JoinEx<T,U,Key>(this IQueryable<T> tableA,IQueryable<U> tableB, Expression<Func<T, Key>> column1, Expression<Func<U, Key>> column2)
            {
                return tableA.Join(tableB, column1, column2, (y, z) => new ABDTO<T,U> {A= y, B=z });
            }
        }
