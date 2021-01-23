    public static class Helper
    {
        public class JoinCondition<TFirst, TSecond>
        {            
            public TFirst column1 { get; set; }
            public TSecond column2 { get; set; }
        }
    
        public static IQueryable<SomeDTO<T, U>> JoinExtension<T, U, TFirst, TSecond>(this IQueryable<T> tableA, IQueryable<U> tableB, 
            Expression<Func<T, JoinCondition<TFirst, TSecond>>> joinSelectorA, 
            Expression<Func<U, JoinCondition<TFirst, TSecond>>> joinSelectorB)
        {
            return tableA.Join(tableB, joinSelectorA, joinSelectorB, (x, y) => new SomeDTO<T, U> { TableA = x, TableB = y });
        }
    }
