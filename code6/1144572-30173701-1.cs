        public static Expression<Func<T, bool>> FilterByCode<T>(List<string> codes)
        {
            var methodInfo = typeof(List<string>).GetMethod("Contains", 
                new Type[] { typeof(string) });
            var list = Expression.Constant(codes);
            var param = Expression.Parameter(typeof(T), "j");
            var value = Expression.Property(param, "Code");
            var body = Expression.Call(list, methodInfo, value);
            // j => codes.Contains(j.Code)
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
