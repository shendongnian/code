    public static class FilterExtensions
    {
        public static bool Matches<T>(this T input, IFilter<T> filter) 
            where T : struct, IConvertible, IComparable
        {
            return filter.Matches(input);
        }
    }
    List<Product> products = context.Products.Where(x => x.Rating.Matches(filter));
