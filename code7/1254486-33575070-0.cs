            using (var client = new DocumentClient(new Uri(endpoint), authKey))
            {
                var collLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
                var account = new Account { Calendar = new Calendar{ Entries = new List<Entry> { new Entry { EntryDate = new DateEpoch { Date = DateTime.UtcNow } } }} };
                var doc = client.CreateDocumentAsync(collLink, account).Result;
                foreach (Account acc in client.CreateDocumentQuery<Account>(collLink)
                                    .Where(d => d.Id == doc.Resource.Id)
                                    .AsEnumerable())
                {
                    System.Diagnostics.Debug.WriteLine(acc.ToString());
                };
            }
