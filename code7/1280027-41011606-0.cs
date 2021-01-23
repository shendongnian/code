        ClientConfiguration example
    
    var config = new ClientConfiguration
    {
      Servers = new List<Uri>
      {
        new Uri("http://192.168.56.101:8091/pools"),
        new Uri("http://192.168.56.102:8091/pools"),
        new Uri("http://192.168.56.103:8091/pools"),
        new Uri("http://192.168.56.104:8091/pools"),
      },
      UseSsl = true,
      DefaultOperationLifespan = 1000,
      BucketConfigs = new Dictionary<string, BucketConfiguration>
      {
        {"default", new BucketConfiguration
        {
          BucketName = "default",
          UseSsl = false,
          Password = "",
          DefaultOperationLifespan = 2000,
          PoolConfiguration = new PoolConfiguration
          {
            MaxSize = 10,
            MinSize = 5,
            SendTimeout = 12000
          }
        }}
      }
    };
    
    using (var cluster = new Cluster(config))
    {
      IBucket bucket = null;
      try
      {
        bucket = cluster.OpenBucket();
        //use the bucket here
      }
      finally
      {
        if (bucket != null)
        {
          cluster.CloseBucket(bucket);
        }
       }
      }
    }
