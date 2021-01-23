    private static void ParseUrl(string url)
            {
                string host = null;
                var port = 123;
                var prefix = 0; 
                if (url.Contains("://"))
                {
                    if (url.StartsWith("http://"))
                        prefix = 7; // length of "http://"
                    else if (url.StartsWith("https://"))
                    {
                        prefix = 8; // length of "https://"
                        port = 443;
                    }
                    else
                    {
                        throw new Exception("Expected scheme missing or unsupported");
                    }
                }
    
                var slash = url.IndexOf('/', prefix);
                string authority = null;
                if (slash == -1)
                {
                    // case 1
                    authority = url.Substring(prefix);
                }
                else
                    if (slash > 0)
                        // case 2
                        authority = url.Substring(prefix, slash - prefix);
    
                if (authority != null)
                {
                    Console.WriteLine("Auth is " + authority);
                    // authority is either:
                    // a) hostname
                    // b) hostname:
                    // c) hostname:port
    
                    var c = authority.IndexOf(':');
                    if (c < 0)
                        // case a)
                        host = authority;
                    else
                        if (c == authority.Length - 1)
                            // case b)
                            host = authority.TrimEnd('/');
                        else
                        {
                            // case c)
                            host = authority.Substring(0, c);
                            port = int.Parse(authority.Substring(c + 1));
                        }
                }
                Console.WriteLine("The Host {0} and Port : {1}", host, port);
            }
