        private IEnumerable<T> GetConsumingEnumerable<T>(BlockingCollection<T> sourceCollection)
        {
            var buffer = new List<T>();
            foreach (var item in sourceCollection.GetConsumingEnumerable())
            {
                buffer.Add(item);
                if (buffer.Count >= sourceCollection.BoundedCapacity)
                {
                    foreach (var bItem in buffer)
                    {
                        yield return bItem;
                    }
                    buffer.Clear();
                }
            }
            foreach (var bItem in buffer)
            {
                yield return bItem;
            }
        }
