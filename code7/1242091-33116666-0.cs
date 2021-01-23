    public static class Extensions
    {
        public IQueryable<T> FindMinimum<T>(this IQueryable<T> source,string rule)
            where T : YourEntityType
        {
            return source.Where(p => p.GradeRule==rule && score>= p.MinScore && score<= p.MaxScore);
        }
    }
