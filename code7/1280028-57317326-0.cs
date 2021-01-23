    var clusterConfig = new ClientConfiguration
    {
    	Servers = new List<Uri>{new Uri("http://couchbase0-node.io:8091")},
    	PoolConfiguration = new PoolConfiguration()
    };
    
    using (var cluster = new Cluster(clusterConfig))
    {
        var authenticator = new PasswordAuthenticator(username, password);
    	cluster.Authenticate(authenticator);
        using (var bucket = cluster.OpenBucket(bucketName))
        {
            // Do something like :
    		var data = await bucket.GetAsync<T>(cacheKey);
    		// Other staff
        }
    }
