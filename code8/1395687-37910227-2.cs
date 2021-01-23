    public static class SearchPredicates
    {
        public static Expression<Func<T, bool>> PolicyNumber<T>(SearchModel search) where T : class 
        {
            return x => predicate_using_PolicyNumber(x, search);
        }
    
        public static Expression<Func<T, bool>> ByUniqueId<T>(SearchModel search) where T : class 
        {
            return x => predicate_using_UniqueId(x, search);
        }
    
        public static Expression<Func<T, bool>> ByPostCode<T>(SearchModel search) where T : class 
        {
            return x => predicate_using_PostCode(x, search);
        }
    }
