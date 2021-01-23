       private static async Task QueryItemDocumentsUsingRestApi()
        {
           //About rest end points to query documents here https://msdn.microsoft.com/en-us/library/azure/mt670897.aspx
            IEnumerable<string> continuationTokens = null;
            var continToken = string.Empty;
            var verb = "POST";
            var resourceType = "docs";
            var resourceLink = string.Format("dbs/{0}/colls/{1}/docs", DatabaseName, CollectionName);
            var resourceId = string.Format("dbs/{0}/colls/{1}", DatabaseName, CollectionName)
            var authHeader = GenerateAuthSignature(verb, resourceId, resourceType, authorizationKey, "master", "1.0"); // look here for how this is generated https://github.com/Azure/azure-documentdb-dotnet/blob/master/samples/rest-from-.net/Program.cs
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-ms-date", _utcDate);
                client.DefaultRequestHeaders.Add("x-ms-version", "2015-08-06");
                client.DefaultRequestHeaders.Remove("authorization");
                client.DefaultRequestHeaders.Add("authorization", authHeader);
                client.DefaultRequestHeaders.Add("x-ms-documentdb-isquery", "True");
                client.DefaultRequestHeaders.Add("x-ms-max-item-count", "5");
                client.DefaultRequestHeaders.Add("x-ms-continuation", string.Empty);
                var qry = new RestSqlQuery { query = "SELECT * FROM items" };
                var result = client.PostWithNoCharSetAsync(new Uri(new Uri(endpointUrl), resourceLink), qry).Result;
                var content = await result.Content.ReadAsStringAsync();
                var pagedList = JsonConvert.DeserializeObject<PagedList>(content);
                
                if (result.Headers.TryGetValues("x-ms-continuation", out continuationTokens))
                {
                    continToken = continuationTokens.FirstOrDefault();
                }
            }
      }
