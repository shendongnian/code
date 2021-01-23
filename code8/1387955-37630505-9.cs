    public static class KeywordSearchExtender
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> data, OrderExpressions<T> mapper, params string[] arguments)
        {
            if (arguments.Length == 0)
                throw new ArgumentException(@"You need at least one argument!", "arguments");
            List<SortArgument> sorting = arguments.Select(a => new SortArgument(a)).ToList();
            IOrderedQueryable<T> result = null;
            for (int i = 0; i < sorting.Count; i++)
            {
                SortArgument sort = sorting[i];
                Expression<Func<T, object>> lambda = mapper[sort.Keyword];
                if (i == 0)
                    result = sorting[i].Ascending ? data.OrderBy(lambda) : data.OrderByDescending(lambda);
                else
                    result = sorting[i].Ascending ? result.ThenBy(lambda) : result.ThenByDescending(lambda);
            }
            return result;
        }
    }
    public class SortArgument
    {
        public SortArgument()
        { }
        public SortArgument(string term)
        {
            if (term.StartsWith("-"))
            {
                Ascending = false;
                Keyword = term.Substring(1);
            }
            else if (term.StartsWith("+"))
            {
                Ascending = true;
                Keyword = term.Substring(1);
            }
            else
            {
                Ascending = true;
                Keyword = term;
            }
        }
        public string Keyword { get; set; }
        public bool Ascending { get; set; }
    }
