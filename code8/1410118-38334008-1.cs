    //Seting up inputs
    IList<string> strings  = new List<string> {"1.1", "2.2", "3.3"};
    IEnumerable<string> enumerableStrings = strings.Select(x => x);
    ObservableCollection<string> observableStrings = new ObservableCollection<string>(strings);
    //Converting
    IList<decimal> resultList = strings.Convert(decimal.Parse);
    IEnumerable<decimal> resultEnumerable = enumerableStrings.Convert(decimal.Parse);
    ObservableCollection<decimal> observableResult = observableStrings.Convert(decimal.Parse);
    public static class EnumerableExtensions
    {
        public static IList<TOutput> Convert<TInput, TOutput>(this IList<TInput> source, Func<TInput, TOutput> itemConversion)
        {
            return source.Select(itemConversion).ToList();
        }
        public static IEnumerable<TOutput> Convert<TInput, TOutput>(this IEnumerable<TInput> source, Func<TInput, TOutput> itemConversion)
        {
            return source.Select(itemConversion);
        }
        public static ObservableCollection<TOutput> Convert<TInput, TOutput>(this ObservableCollection<TInput> source, Func<TInput, TOutput> itemConversion)
        {
            return new ObservableCollection<TOutput>(source.Select(itemConversion));
        }
    }
