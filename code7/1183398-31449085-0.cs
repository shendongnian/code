     ClusterHelper.Initialize(
                new ClientConfiguration
                {
                    Servers = serverList,
                    UseSsl = false,
                    DefaultOperationLifespan = 2500,
                    EnableTcpKeepAlives = true,
                    TcpKeepAliveTime = 1000*60*60,
                    TcpKeepAliveInterval = 5000,
                    BucketConfigs = new Dictionary<string, BucketConfiguration>
                    {
                        {
                            "default",
                            new BucketConfiguration
                            {
                                BucketName = "default",
                                UseSsl = false,
                                Password = "",
                                PoolConfiguration = new PoolConfiguration
                                {
                                    MaxSize = 50,
                                    MinSize = 10
                                }
                            }
                        }
                    }
                });
