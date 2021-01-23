    public void MapCollectionsInPlace<TSource, TDestination>(IEnumerable<TSource> source_collection,
        IEnumerable<TDestination> destination_collection)
    {
        var source_enumerator = source_collection.GetEnumerator();
        var destination_enumerator = destination_collection.GetEnumerator();
        while (source_enumerator.MoveNext())
        {
            if(!destination_enumerator.MoveNext())
                throw new Exception("Source collection has more items than destination collection");
            AutoMapper.Mapper.Map(source_enumerator.Current, destination_enumerator.Current);
        }
    }
