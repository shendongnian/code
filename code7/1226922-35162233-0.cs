        using System.Net.NetworkInformation;
        public static bool IsConnectedToServer()
        {
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send("XXX.XXX.XXX.XXX", 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
                else return false;
            }
            catch { return false; }
        }
