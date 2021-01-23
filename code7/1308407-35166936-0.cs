    public IEnumerable<IEnumerable<T>> GetChunks<T>(IEnumerable<T> elements, int size)
    {
        var list = elements.ToList();
        while (list.Count > 0)
        {
            var chunk = list.Take(size);
            yield return chunk;
            list = list.Skip(size).ToList();
        }
    }
