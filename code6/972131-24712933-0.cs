    public class VerifyInternetAccess
    {
        private static bool HasConnection = false;
        static VerifyInternetAccess()
        {
            NetworkChange.NetworkAvailabilityChanged += (o, ca) =>
                {
                    HasConnection = ca.IsAvailable;
                };
    
            HasConnection = NetworkInterface.GetIsNetworkAvailable();
        }
    
        public static bool HasInternet()
        {
            bool hasEnded = false;
            if (!HasConnection)
            {
                // let's try to wake up...
                using (var ping = new Ping())
                {
                    var iphost = Dns.GetHostEntry("www.google.com");
                           
                    foreach (var addr in iphost.AddressList)
                    {
                        var reply = ping.Send(addr);
                        if (reply.Status == IPStatus.Success)
                        {
                            HasConnection = true;
                            break;
                        }
                    }
                }
            }
            return HasConnection;
        }
    }
