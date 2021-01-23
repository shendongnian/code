    public class WemoScanner
    {
        public delegate void WemoDeviceFound(WemoDevice device);
        public event WemoDeviceFound OnWemoDeviceFound;
        public void StartScanning()
        {
            var addresses = GetAddresses().Where(a => a.Type == "Dynamic");
            var tasks = addresses.SelectMany(CheckWemoDevice);
            Task.Run(async () => { await Task.WhenAll(tasks).ConfigureAwait(false); });
        }
        private NetshResult[] GetAddresses()
        {
            Process p = new Process();
            p.StartInfo.FileName = "netsh.exe";
            p.StartInfo.Arguments = "interface ip show ipnet";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            var lines =
                output.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .SkipWhile(l => !l.StartsWith("--------"))
                    .Skip(1);
            var results =
                lines.Select(l => new NetshResult(l.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)))
                    .ToArray();
            return results;
        }
        private IEnumerable<Task> CheckWemoDevice(NetshResult netshResult)
        {
            var tasks = new List<Task>();
            for (uint i = 49150; i <= 49156; i++)
            {
                tasks.Add(CheckWemoDevice(netshResult.IpAddress, i));
            }
            return tasks;
        }
        private async Task CheckWemoDevice(string ip, uint port)
        {
            var url = $"http://{ip}:{port}/setup.xml";
            try
            {
                using (var wc = new WebClient())
                {
                    var resp = await wc.DownloadStringTaskAsync(url);
                    if (resp.Contains("Belkin")) // TODO: Parse upnp device data and determine device
                        OnWemoDeviceFound?.Invoke(new WemoDevice {Address = ip, Port = port});
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
