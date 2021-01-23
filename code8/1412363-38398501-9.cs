    public class SrvClient : ClientBase<ISrvService>
    {
        public async Task<string> LongRunningOperation()
        {
            return await base.Channel.LongRunningOperation();
        }
        public async Task<bool> Ping()
        {
            // note that we still call this with an await. In the client we are awaiting the wcf service call
            // this is independent of any async/await that happens on the server
            return await Task.Run(() => base.Channel.Ping());
        }
    }
