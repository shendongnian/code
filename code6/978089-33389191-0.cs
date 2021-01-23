                try
                {
                    _collection.CreateIndex(keys, options);
                }
                catch (MongoWriteConcernException ex)
                {
                    //probably index exists with different options, lets check if name is specified
                    var optionsDoc = options.ToBsonDocument();
                    if (!optionsDoc.Names.Contains("name"))
                        throw;
                    var indexName = optionsDoc["name"].AsString;
                    _collection.DropIndexByName(indexName);
                    _collection.CreateIndex(keys, options);
                }
