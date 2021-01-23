    public static class NamedEntityExtensions
    {
        public static IList<NamedEntity<T>> MergeEntities<T>(this IList<NamedEntity<T>> list1, IList<NamedEntity<T>> list2)
            where T: TweetModel
        {
            foreach(NamedEntity<T> entity1 in list1)
            {
                foreach(NamedEntity<T> entity2 in list2)
                {
                    if(entity1.Name == entity2.Name)
                    {
                        entity1.Tweets.AddRange(entity2.Tweets);
                    }
                }
            }
            return list1; //original list will get augmented but returning it allows chaining
        }
    }
