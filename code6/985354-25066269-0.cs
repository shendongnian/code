    joined = list1.Union(list2)
                          .GroupBy(o => o.Name)
                          .Select(o =>
                          {
                              Entity<Tweet> entity = null;
                              string className = o.First().GetType().Name;
                              Type t = Type.GetType("FinalUniProject.NERModels." + className);
                              entity = (Entity<Tweet>)Activator.CreateInstance(t);
                              entity.Name = o.Key;
                              // Allow for inverted index by adding tweet to NamedEntist List<TweetModel>
                              entity.tweets = o.ToList().SelectMany(x => x.tweets).ToList();
                              return entity;
                          }).ToList();
