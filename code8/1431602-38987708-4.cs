    public static bool ResolveTest(string hostNameOrAddress, int millisecond_time_out)
    {
        ResolveState ioContext = new ResolveState(hostNameOrAddress);
        var result = Dns.BeginGetHostEntry(ioContext.HostName, null, null);
        var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(millisecond_time_out), true);
        if (!success)
        {
            ioContext.Result = ResolveType.Timeout;
        }
        else
        {
            try
            {
                var ipList = Dns.EndGetHostEntry(result);
                if (ipList == null || ipList.AddressList == null || ipList.AddressList.Length == 0)
                    ioContext.Result = ResolveType.InvalidHost;
                else
                    ioContext.Result = ResolveType.Completed;
            }
            catch
            {
                ioContext.Result = ResolveType.InvalidHost;
            }
        }
        Console.WriteLine($"The result of ResolveTest for {ioContext.HostName} is {ioContext.Result}");
        return ioContext.Result == ResolveType.Completed;
    }
