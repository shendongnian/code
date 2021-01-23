            var config = new ClientConfiguration
            {
                Servers = new List<Uri> { 
                    new Uri("http://10.0.0.XX:8091/pools")
                },
                UseSsl = false,
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
                  }
                 }
                }
            };
          Cluster cbCluster = new Cluster(config);
          Document<object> cbDoc = new Document<dynamic> { 
                            Id = _key,
                            Content = new
                            {
                                id = "a"
                            }
                        };
          //UPSERT
          var upsert = cbBucket.Upsert(cbDoc);
          ....
