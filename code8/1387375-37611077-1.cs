     static async Task GetMyInstance<T>(ForceClient client) where T : Parent
        {
            Console.WriteLine("Get " + T.GetType().Name);
            var accts = new List<T>();
            var results = await client.QueryAsync<T>(T._select);
            var totalSize = results.TotalSize;
            Console.WriteLine("Queried " + totalSize + " " + T.GetType().Name +".");
            accts.AddRange(results.Records);
            Console.WriteLine("Added " + results.Records.Count + T.GetType().Name + "...");
            var nextRecordsUrl = results.NextRecordsUrl;
            if (!string.IsNullOrEmpty(nextRecordsUrl))
            {
                Console.WriteLine("Found more records...");
                while (true)
                {
                    var continuationResults = await client.QueryContinuationAsync<T>(nextRecordsUrl);
                    Console.WriteLine("Queried an additional " + continuationResults.Records.Count + " " + T.GetType().Name + ".");
                    accts.AddRange(continuationResults.Records);
                    if (string.IsNullOrEmpty(continuationResults.NextRecordsUrl)) break;
                    nextRecordsUrl = continuationResults.NextRecordsUrl;
                }
            }
            Upsert(accts, T.target);
        }
