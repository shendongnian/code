    MongoCollection<AnalyticsClicks> dbCollection = DetermineCollectionName<AnalyticsClicks>();
    
                var match = new BsonDocument 
                { 
                    { 
                        "$match", 
                        new BsonDocument {{"UserId", userId}, {"CampaignId", campaignId}} 
                    } 
                };
    
                var group = new BsonDocument 
                { 
                    { "$group", 
                        new BsonDocument 
                        { 
                            { "_id", new BsonDocument {{"Email", "$Email" }, {"Link", "$Link"}, }}, 
                        } 
                    } 
                };
    
                AggregateArgs pipeline = new AggregateArgs()
                {
                    Pipeline = new[] { match, group }
                };
                var result = dbCollection.Aggregate(pipeline);
                return Convert.ToInt32(result.Count());
