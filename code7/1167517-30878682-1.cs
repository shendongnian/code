    public IEnumerable<Row> GetRows(string query)
    {
        using (var resetEvent = new AutoResetEvent(false))
        {
            var rows = new ConcurrentQueue<Row>();
            var queryTask = Task.Run(() => DoQueryWithCallback(query, r =>
            {
                rows.Enqueue(r);
                resetEvent.Set();
            }));
            queryTask.ContinueWith(t => resetEvent.Set()); // This ensures that queryTask.IsCompleted will be true in the while loop below
            while (resetEvent.WaitOne() && !queryTask.IsCompleted)
            {
                Row row;
                while (rows.TryDequeue(out row))
                    yield return row;
            }
        }
    }
