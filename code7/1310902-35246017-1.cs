    public static class Extensions
    {
        public static void ForeEach<TIn, TOut>(this List<TIn> TheCollection, Func<TIn, TOut> ProcessFunction)
        {
            TheCollection.ForEach((item) => ProcessFunction(item));
        }
    }
