    public IEnumerable<Row> GetRows(string query)
    {
        using (var rows = new BlockingCollection<Row>())
        {
            Task.Run(() =>
            {
                DoQueryWithCallback(query, r => rows.Add(r));
                rows.CompleteAdding();
            });
            while (!rows.IsCompleted)
                yield return rows.Take();
        }
    }
