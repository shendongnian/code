    public async Task<BlockData.Block> Last()
    {
        return await new AsyncConnector(Connection).Get<BlockData.Block>(
            "/chain/last-block");
    }
    
    public class AsyncConnector
    {
        NisConnection Connection = null;
    
        public AsyncConnector(NisConnection connection)
        {
            Connection = connection;
        }
    
        public async Task<T> Get<T>(string uri)
        {
            var response = await Connection.Client.GetAsync(Connection.FullUri(uri));
            return await response.Content.ReadAsAsync<T>();
        }
    }
