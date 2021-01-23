    public class PingTruck
    {
        public string PingStatus;
        public string PingMethod()
        {
            string IPAddress = "127.0.0.1";
            int timeout = 7;
            try
            {   Ping Truck = new Ping();
                PingReply reply = Truck.Send(IPAddress, timeout);
                if (reply.Status == IPStatus.Success)
                    return PingStatus = "Found Truck";
                else
                    return PingStatus = "Can't Find Truck";
            }
            catch (PingException)
            {
                return PingStatus = "No Truck";
            }
        }
    }
