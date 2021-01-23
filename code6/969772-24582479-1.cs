    private List<NamedEntity<TweetModel>> joinLists(List<NamedEntity<TweetModel>> list1, List<NamedEntity<TweetModel>> list2)
    {
    	List<NamedEntity<TweetModel>> joined;
    
    	joined = list1.Union(list2)
    				  .GroupBy(o => o.Name)
    				  .Select(o => new NamedEntity<TweetModel>
    								 {
    									 Name = o.Key,
    									 tweets =
    										 o.SelectMany(x => x.tweets).ToList()
    								 }).ToList();
    	
    	return joined;
    }
