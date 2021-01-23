            var totalResultsToFetch = 500;
            TableQuery<Footwear> query = table.CreateQuery<Footwear>().Where(f => f.PartitionKey == partitionKey).Take(totalResultsToFetch).AsTableQuery();
            TableContinuationToken token = null;
            List<Footwear> shoes = new List<Footwear>();
            do
            {
                TableQuerySegment<Footwear> queryResult = query.ExecuteSegmented(token);
                token = queryResult.ContinuationToken;
                shoes.AddRange(queryResult.Results);
                totalResultsToFetch -= queryResult.Results.Count;
                query = table.CreateQuery<Footwear>().Where(f => f.PartitionKey == partitionKey).Take(totalResultsToFetch).AsTableQuery();
            } while (token != null && (totalResultsToFetch > 0));
