    var itemBuckets= Sitecore.Context.Database.GetItem(bucketPath);
      if (itemBuckets!= null && BucketManager.IsBucket(itemBuckets))
      {     
         using (var searchContext = ContentSearchManager.GetIndex(itemBuckets as IIndexable).CreateSearchContext())
        {
            var result = searchContext.GetQueryable<SearchResultItem().Where(x => x.Name == itemName).FirstOrDefault();
            if(result != null)
                Context.Item = result.GetItem();
        }
      } 
