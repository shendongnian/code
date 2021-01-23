    public static class ListExtensions
    {
        public static TList Populate<TList, TElement>(this TList list, params TElement[] values)
            where TList : IList<TElement>
        {
            // TODO: argument validation
            for (int i = 0; i < values.Length; i++)
                list[i] = values[i];
            return list;
        }
    }
