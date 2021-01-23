        protected string GetIPAddress()
        {
            var context = HttpContext.Current;
            var ip = context.Request.ServerVariables["REMOTE_ADDR"];
            if (!IsInternal(ip)) {
                string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                ip = !string.IsNullOrEmpty(ipAddress) ? ipAddress.Split(',')[0] : "0.0.0.0";
            }
            return ip;
        }
        /* An IP should be considered as internal when:
         
           ::1          -   IPv6  loopback
           10.0.0.0     -   10.255.255.255  (10/8 prefix)
           127.0.0.0    -   127.255.255.255  (127/8 prefix)
           172.16.0.0   -   172.31.255.255  (172.16/12 prefix)
           192.168.0.0  -   192.168.255.255 (192.168/16 prefix)
         */
        public bool IsInternal(string testIp)
        {
            if(testIp == "::1") return true;
            byte[] ip = IPAddress.Parse(testIp).GetAddressBytes();
            switch (ip[0])
            {
                case 10:
                case 127:
                    return true;
                case 172:
                    return ip[1] >= 16 && ip[1] < 32;
                case 192:
                    return ip[1] == 168;
                default:
                    return false;
            }
        }
