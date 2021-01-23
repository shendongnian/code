    	public async Task<Result> GetResultAsync(Site site, string indexableType, SearchQuery searchQuery)
        {
            using (var provider = new Provider(Logger))
            {
                var indexableT = typeof(IIndexable).Assembly
                                            .GetTypes()
                                            .FirstOrDefault(t => typeof(IIndexable).IsAssignableFrom(t) && t.Name == indexableType);
                if (indexableT != null)
                {
                    var generic = provider
                                    .GetType()
                                    .GetMethod("METHOD_NAME_IN_PROVIDER"))
                                    .MakeGenericMethod(indexableT);                    
									
					//This is the same as calling: await provider.METHOD_NAME_IN_PROVIDER<T>(site, searchQuery);
					return await (Task<Result>) generic.Invoke(provider, new object[] { site, searchQuery });
                }
                return null;
            }
        }
