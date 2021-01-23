    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] companies =
            {
                "Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light",
                "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works",
                "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
            };
            var intResults = companies.WhereIsOfType<string, int>();
            Console.WriteLine(intResults.Count()); //0
            var stringResults = companies.WhereIsOfType<string, string>();
            Console.WriteLine(stringResults.Count()); //18
        }
    }
    public static class Extensions
    {
        public static IEnumerable<TInput> WhereIsOfType<TInput, TResult>(this IEnumerable<TInput> source)
        {
            var queryableSource = source.AsQueryable();
            var pe = Expression.Parameter(typeof (TInput), "x");
            var left = Expression.Constant(pe.Name);
            var expr = Expression.TypeIs(left, typeof (TResult));
            var whereCallexp = Expression.Call(
                typeof (Queryable),
                "Where",
                new[] {typeof (TInput)},
                queryableSource.Expression,
                Expression.Lambda<Func<TInput, bool>>(expr, pe));
            var results = queryableSource.Provider.CreateQuery<TInput>(whereCallexp);
            return results;
        }
    }
