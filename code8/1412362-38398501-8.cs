    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SrvService : ISrvService
    {
        MyObject statusObject;
        public async Task LongRunningOperation()
        {
            // lock/semaphore here if needed
            await Task.Run(() => statusObject.elaborateStatus()); // you could impliment elaborateStatus() as an async Task method and call it without Task.Run
            return statusObject.ToString();
        }
        public bool Ping()
        {
            return true;
        }
        public SrvService()
        {
            statusObject= ...statusObject init...
        }
    }
    
