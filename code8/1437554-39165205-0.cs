    var update = Builders<UserFeed>
                        .Update
                        .CurrentDate(x => x.DateLastUpdated)
                        .PushEach(x =>
                            x.Items,
                            new List<FeedItemBase> { feedItem },
                            50)
                            .Inc(x => x.Count, 1);
                    var result = await Collection.UpdateOneAsync(x =>
                        x.User.Id == userFeedToWriteTo && x.Count < 50,
                        update,
                        new UpdateOptions { IsUpsert = true }
                        ).ConfigureAwait(false);
