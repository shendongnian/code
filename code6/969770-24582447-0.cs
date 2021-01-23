    private IEnumerable<NamedEntity<TweetModel>> Join(
        IEnumerable<NamedEntity<TweetModel>> list1,
        IEnumerable<NamedEntity<TweetModel>> list2)
    {
        return list1.Join(list2, item => item.Name, item => item.Name, (outer, inner) =>
        {
            outer.tweets.AddRange(inner.tweets);
            return outer;
        });
    }
