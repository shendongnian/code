        public static bool TryPing(string hostNameOrAddress, out string pingStatusMessage, out string pingAddressMessage)
        {
            if (String.IsNullOrWhiteSpace(hostNameOrAddress))
            {
                pingStatusMessage = "Missing host name";
                pingAddressMessage = "";
                return false;
            }
            var data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var buffer = Encoding.ASCII.GetBytes(data);
            var timeout = 120;
            using (var p = new Ping())
            {
                var options = new PingOptions();
                options.DontFragment = true;
                try
                {
                    var r = p.Send(hostNameOrAddress, timeout, buffer, options);
                    if (r.Status == IPStatus.Success)
                    {
                        pingStatusMessage = "Ping to " + hostNameOrAddress.ToString() + "[" + r.Address.ToString() + "]" + " (Successful) "
                          + "Bytes =" + r.Buffer.Length + " TTL=" + r.Options.Ttl + " Response delay = " + r.RoundtripTime.ToString() + " ms " + "\n";
                        pingAddressMessage = r.Address.ToString();
                        return true;
                    }
                    else
                    {
                        // just to know the ip for the website if they block the icmp protocol
                        pingStatusMessage = r.Status.ToString();
                        var ips = Dns.GetHostAddresses(hostNameOrAddress);
                        pingAddressMessage = String.Join(",", ips.Select(ip => ip.ToString()));
                        return false;
                    }
                }
                catch (PingException ex)
                {
                    pingStatusMessage = string.Format("Error pinging {0}: {1}", hostNameOrAddress, (ex.InnerException ?? ex).Message);
                    pingAddressMessage = hostNameOrAddress;
                    return false;
                }
            }
        }
