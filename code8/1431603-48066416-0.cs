    private Task<IPAddress> ResolveAsync(string hostName) {
        return System.Threading.Tasks.Task.Run(() => {
            return System.Net.Dns.GetHostEntry(hostName).AddressList[0];
        });
    }
 
    private string ResolveWithTimeout(string hostNameOrIpAddress) {
        var timeout = TimeSpan.FromSeconds(3.0);
        var task = ResolveAsync(hostNameOrIpAddress);
        if (!task.Wait(timeout)) {
            throw new TimeoutException();
        }
        return task.Result.ToString();
    }
