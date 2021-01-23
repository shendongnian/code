    public class TableSyncHandler : IMobileServiceSyncHandler
    {
        private readonly IMobileServiceClient _client;
        private readonly HashSet<string> _excludedTables = new HashSet<string>();
        public TableSyncHandler(IMobileServiceClient client)
        {
            _client = client;
        }
        public void Exclude<T>()
        {
            _excludedTables.Add(_client.SerializerSettings.ContractResolver.ResolveTableName(typeof(T)));
        }
        public Task OnPushCompleteAsync(MobileServicePushCompletionResult result)
        {
            return Task.FromResult(0);
        }
        public Task<JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
        {
            if (_excludedTables.Contains(operation.Table.TableName))
            {
                return Task.FromResult((JObject) null);
            }
            return operation.ExecuteAsync();
        }
    }
