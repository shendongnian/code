    Task.Factory.StartNew(() => client.GetCollactions(username).ToList())
    .ContinueWith(result =>
    {
        foreach (CardSet collection in result.Result)
        {
            CollectionList.Items.Add(collection.name);
        }
    },TaskScheduler.FromCurrentSynchronizationContext());
 
