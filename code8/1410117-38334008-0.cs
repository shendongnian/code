    IList<string> strings  = new List<string> {"1.1", "2.2", "3.3"};
    IList<decimal> result = ConvertToSameListType(strings, (Func<string, decimal>)decimal.Parse, () => new List<decimal>());
    public static class EnumerableExtensioncGeneralVersion
    {
        public static TOutputList ConvertToSameListType<TInputList, TOutputList, TInput, TOutput>(this TInputList source, Func<TInput, TOutput> itemConversion, Func<TOutputList> outputListConstructor)
            where TInputList : IEnumerable<TInput>
            where TOutputList : ICollection<TOutput>
        {
            TOutputList result = outputListConstructor();
            foreach (TOutput convertedItem in source.Select(itemConversion))
            {
                result.Add(convertedItem);
            }
            return result;
        }
    }
