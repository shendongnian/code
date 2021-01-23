    var working = new ConcurrentBag<IpItem>(); // not sure what your type is
    [....]
    using (var client = new ProxyClient(ip, u, p))
                            {
                                Console.WriteLine(u + p + ip_item.IP);
                                client.Connect();
                                ip_item.AcceptsConnection = client.IsConnected;
                                client.Disconnect();
                                working.Add(ip_item);
                            }
