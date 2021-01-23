    public static class CollectionMappingExtensions
    {
        public static void MapTo<TSource, TTarget, TItem>(this TSource source, TTarget target, IMapper mapper)
            where TSource : ICollection<TItem>
            where TTarget : ICollection<TItem>
        {
            foreach (TItem item in source)
            {
                TItem targetItem = target.SingleOrDefault(someItem => someItem.Equals(someItem));
                if (targetItem == null)
                    target.Add(item);
                else
                    mapper.Map(item, targetItem);
            }
        }
    }
