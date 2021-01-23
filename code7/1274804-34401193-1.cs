    public static void AddToSearchIndex([QueueTrigger("indexsearchadd")] List<ListingItem> items, TextWriter log)
    {
        ...
        indexWriter = new IndexWriter(azureDirectory, …);
 
        foreach (var itm in items)
        {
            AddtoIndex(itm, indexWriter);
        }
        indexWriter.Commit();
    }
