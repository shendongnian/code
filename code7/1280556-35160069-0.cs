    //this is your existing code, wrapped into a function
    List<ContentData> GetCollectionContent(long collectionID)
    {
        var contentManager = new ContentManager();
        var criteria = new ContentCollectionCriteria(ContentProperty.Id, EkEnumeration.OrderByDirection.Ascending);
        criteria.AddFilter(collectionID);
        return contentManager.GetList(criteria);
    }
    //builds the mapping from step #1 above
    Dictionary<ContentData, List<ContentCollectionData>> BuildCollectionMapping()
    {
        //get all the collections in the system (using a new, "default" criteria object)
        var collectionManager = new CollectionManager();
        var allCollections = collectionManager.GetList(new CollectionCriteria());
        //build the mapping, associate a content item with each collection it is in
        var mapping = new Dictionary<ContentData, List<ContentCollectionData>>();
        foreach (var collection in allCollections)
        {
            var contentItems = GetCollectionContent(collection.Id);
            foreach (var contentItem in contentItems)
            {
                if (!mapping.ContainsKey(contentItem))
                {
                    mapping.Add(contentItem, new List<ContentCollectionData>());
                }
                mapping[contentItem].Add(collection);
            }
        }
        return mapping;
    }
    //steps #2-3 from above, using the variables you defined
    void Reconcile(long iPName, List<string> sColl)
    {
        var mapping = BuildCollectionMapping();
        if (mapping.Keys.Any(content => content.Id == iPName))
        {
            var collections = mapping.Single(kvp => kvp.Key.Id == iPName).Value;
            var collectionTitles = collections.Select(c => c.Title);
            //these are the names of collections to which this content item must be added
            var toAdd = sColl.Except(collectionTitles);
            //these are the names of collections from which the content item must be deleted
            var toDelete = collectionTitles.Except(sColl);
        }
    }
    
