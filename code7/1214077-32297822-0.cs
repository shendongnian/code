            /// <summary>
            /// When a client IP can't be determined
            /// </summary>
            public const string UnknownIP = "0.0.0.0"; 
    
            public static string GetRemoteIP(NameValueCollection ServerVariables)
            {
                string ip = ServerVariables["REMOTE_ADDR"]; // could be a proxy -- beware
                string ipForwarded = ServerVariables["HTTP_X_FORWARDED_FOR"];
    
                // check if we were forwarded from a proxy
                if (ipForwarded.HasValue())
                {
                    ipForwarded = _ipAddress.Match(ipForwarded).Value;
                    if (ipForwarded.HasValue() && !IsPrivateIP(ipForwarded))
                        ip = ipForwarded;
                }
    
                return ip.HasValue() ? ip : UnknownIP;
            }
