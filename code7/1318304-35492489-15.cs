    public static class YourLinqExtensions
    {
        public static string Class(this YourEntityBaseClass source)
        { 
            // .Net runtime implementation just in case, useless in linq2nhib case
            return source == null ? null : source.GetType().Name;
        }
    }
