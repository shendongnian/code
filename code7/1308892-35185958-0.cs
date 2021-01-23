            public async Task<Tuple<List<AdDocument>,string,int>> QueryWithPagingAsync(string continuationToken)
        {
            List<AdDocument> ads = new List<AdDocument>();
            var totalAdsCount = await GetAdsCount();if (string.IsNullOrEmpty(continuationToken))
            {
                FeedOptions options = new FeedOptions { MaxItemCount = 5 };
                var query = Client.CreateDocumentQuery<AdDocument>(DocumentCollection.DocumentsLink, options).AsDocumentQuery();
                var feedResponse = await query.ExecuteNextAsync<AdDocument>();
                                foreach (var ad in feedResponse.AsEnumerable().OrderBy(a => a.Id))
                {
                    ads.Add(ad);
                }
                string continuation = feedResponse.ResponseContinuation;
                return new Tuple<List<AdDocument>, string, int>(ads, continuation, totalAdsCount);
            }
            else
            {
                FeedOptions options = new FeedOptions { MaxItemCount = 5, RequestContinuation = continuationToken };
                var query = Client.CreateDocumentQuery<AdDocument>(DocumentCollection.DocumentsLink, options).AsDocumentQuery();
                var feedResponse = await query.ExecuteNextAsync<AdDocument>();
                foreach (var ad in feedResponse.AsEnumerable().OrderBy(a=>a.Id))
                {
                    ads.Add(ad);
                }
                string continuation = feedResponse.ResponseContinuation;
                return new Tuple<List<AdDocument>, string, int>(ads, continuation, totalAdsCount);
            }
            
        }
    public async Task<Tuple<List<AdDocument>,string,int>> QueryWithPagingAsync(string continuationToken)
        {
            List<AdDocument> ads = new List<AdDocument>();
            var totalAdsCount = await GetAdsCount();
            if (string.IsNullOrEmpty(continuationToken))
            {
                FeedOptions options = new FeedOptions { MaxItemCount = 5 };
                var query = Client.CreateDocumentQuery<AdDocument>(DocumentCollection.DocumentsLink, options).AsDocumentQuery();
                var feedResponse = await query.ExecuteNextAsync<AdDocument>();
                                foreach (var ad in feedResponse.AsEnumerable().OrderBy(a => a.Id))
                {
                    ads.Add(ad);
                }
                string continuation = feedResponse.ResponseContinuation;
                return new Tuple<List<AdDocument>, string, int>(ads, continuation, totalAdsCount);
            }
            else
            {
                FeedOptions options = new FeedOptions { MaxItemCount = 5, RequestContinuation = continuationToken };
                var query = Client.CreateDocumentQuery<AdDocument>(DocumentCollection.DocumentsLink, options).AsDocumentQuery();
                var feedResponse = await query.ExecuteNextAsync<AdDocument>();
                foreach (var ad in feedResponse.AsEnumerable().OrderBy(a=>a.Id))
                {
                    ads.Add(ad);
                }
                string continuation = feedResponse.ResponseContinuation;
                return new Tuple<List<AdDocument>, string, int>(ads, continuation, totalAdsCount);
            }
            
        }
