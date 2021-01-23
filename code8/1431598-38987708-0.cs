    public static Task<bool> Resolve(string hostNameOrAddress, int millisecond_time_out)
    {
        return Task.Run(async () =>
        {
            bool completed = false;
            var asCallBack = new AsyncCallback(ar =>
            {
                ResolveState context = (ResolveState)ar.AsyncState;
                if (context.Result == ResolveType.Pending)
                {
                    try
                    {
                        var ipList = Dns.EndGetHostEntry(ar);
                        if (ipList == null || ipList.AddressList == null || ipList.AddressList.Length == 0)
                            context.Result = ResolveType.InvalidHost;
                        else
                            context.Result = ResolveType.Completed;
                    }
                    catch
                    {
                        context.Result = ResolveType.InvalidHost;
                    }
                }
                completed = true;
            });
            ResolveState ioContext = new ResolveState(hostNameOrAddress);
            var result = Dns.BeginGetHostEntry(ioContext.HostName, asCallBack, ioContext);
            int miliCount = 0;
            while (!completed)
            {
                miliCount++;
                if (miliCount >= millisecond_time_out)
                {
                    result.AsyncWaitHandle.Close();
                    result = null;
                    ioContext.Result = ResolveType.Timeout;
                    break;
                }
                await Task.Delay(1);
            }
            Console.WriteLine($"The result of {ioContext.HostName} is {ioContext.Result}");
            return ioContext.Result == ResolveType.Completed;
        });
    }
    
    public class ResolveState
    {
        public ResolveState(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
                throw new ArgumentNullException(nameof(hostName));
            _hostName = hostName;
        }
    
        readonly string _hostName;
    
        public ResolveType Result { get; set; } = ResolveType.Pending;
    
        public string HostName => _hostName;
    
    }
    
    public enum ResolveType
    {
        Pending,
        Completed,
        InvalidHost,
        Timeout
    }
