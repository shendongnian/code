    List<string> indexedList = new List<string>();
    var scanResults = client.Search<ClassName>(s => s
                    .From(0)
                    .Size(2000)
                    .MatchAll()
                    .Fields(f=>f.Field(fi=>fi.propertyName)) //I used field to get only the value I needed rather than getting the whole document
                    .SearchType(Elasticsearch.Net.SearchType.Scan)
                    .Scroll("5m")
                );
            var results = client.Scroll<ClassName>("10m", scanResults.ScrollId);
            while (results.Documents.Any())
            {
                foreach(var doc in results.Fields)
                {
                    indexedList.Add(doc.Value<string>("propertyName"));
                }
                results = client.Scroll<ClassName>("10m", results.ScrollId);
            }
