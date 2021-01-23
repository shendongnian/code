     public static int GetPing(string ip, int timeout)
        {
            int p = -1;
            using (Ping ping = new Ping())
            {
                    PingReply reply = ping.Send(_ip, timeout);
                    if (reply != null)
                        if (reply.Status == IPStatus.Success)
                            p = Convert.ToInt32(reply.RoundtripTime);
            }
            return p;
        }
