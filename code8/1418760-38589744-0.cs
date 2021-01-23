    var clientConfiguration = new ClientConfiguration
    {
        BucketConfigs = new Dictionary<string, BucketConfiguration>
        {
            {
                MembaseBucketName,
                new BucketConfiguration
                {
                    BucketName = MembaseBucketName,
                    Password = MembaseBucketPassword,
                    Servers = root.Elements("servers").Elements("add").Attributes("uri").ToList(_ => new Uri(_.Value)),
                    PoolConfiguration = new PoolConfiguration
                    {
                        MinSize = Convert.ToInt32(root.Element("socketPool").Attribute("minPoolSize").Value),
                        MaxSize = Convert.ToInt32(root.Element("socketPool").Attribute("maxPoolSize").Value),
                        ConnectTimeout = (int)TimeSpan.Parse(root.Element("socketPool").Attribute("connectionTimeout").Value).TotalMilliseconds,
                        WaitTimeout = (int)TimeSpan.Parse(root.Element("socketPool").Attribute("queueTimeout").Value).TotalMilliseconds,
                        SendTimeout = (int)TimeSpan.Parse(root.Element("socketPool").Attribute("receiveTimeout").Value).TotalMilliseconds,
                    },
                    DefaultOperationLifespan = (uint)TimeSpan.Parse(root.Element("socketPool").Attribute("receiveTimeout").Value).TotalMilliseconds, // Belt and braces.
                }
            },
        },
        ViewRequestTimeout = (int)TimeSpan.Parse(root.Element("socketPool").Attribute("receiveTimeout").Value).TotalMilliseconds, // Belt and braces.
    };
