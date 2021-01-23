    internal static class CloudTableExtensions
    {
        public static async Task<IList<DynamicTableEntity>> ExecuteQueryAsync(this CloudTable table,
            TableQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var items = new List<DynamicTableEntity>();
            TableContinuationToken token = null;
            do
            {
                var seg =
                    await
                        table.ExecuteQuerySegmentedAsync(query, token, new TableRequestOptions(), new OperationContext(),
                            cancellationToken);
                token = seg.ContinuationToken;
                items.AddRange(seg);
            } while (token != null && !cancellationToken.IsCancellationRequested
                     && (query.TakeCount == null || items.Count < query.TakeCount.Value));
            return items;
        }
    }
