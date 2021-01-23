    public static class Or<T>
    {
        public static readonly Func<T, T, T> Do;
        static Or()
        {
            var par1 = Expression.Parameter(typeof(T));
            var par2 = Expression.Parameter(typeof(T));
            Expression or;
            if (typeof(T).IsEnum)
            {
                Type type = Enum.GetUnderlyingType(typeof(T));
                or = Expression.Convert(
                    Expression.Or(
                        Expression.Convert(par1, type), 
                        Expression.Convert(par2, type)), 
                    typeof(T));
            }
            else
            {
                or = Expression.Or(par1, par2);
            }
            Do = Expression.Lambda<Func<T, T, T>>(or, par1, par2).Compile();
        }
    }
