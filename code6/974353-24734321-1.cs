    public async Task BlockingCollectionPerformance()
    {
        using (var collection = new BlockingCollection<int>())
        {
            var consumer = Task.Run(() =>
            {
                var i = 0;
                while (collection.TryTake(out i, TimeSpan.FromSeconds(2)))
                {
                    Debug.Print(i.ToString());
                }
            });
            var producer = Task.Run(() =>
            {
                try
                {
                    for (var i = 0; i < 10; i++)
                    {
                        collection.Add(i);
                    }
                }
                finally
                {
                    collection.CompleteAdding();
                }
            });
            await Task.WhenAll(producer, consumer);
        }
    }
