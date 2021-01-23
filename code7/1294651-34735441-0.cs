    result = (from asset in _db.Query<Asset>()
                         where !SqlMethods.Like(asset.Title, "[a-Z]%")
                         select 
                                new AssociatedItem 
                                { 
                                    Id = asset.AssetId, 
                                    Title = asset.Title, 
                                    Type = Constants.FeedbackTypes.ASSET 
                                }).ToList();
