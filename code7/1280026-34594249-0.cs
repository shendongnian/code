        var clientConfiguration = new ClientConfiguration();
        clientConfiguration.Servers = new List<Uri> { new Uri("http://localhost:8091") };
        Cluster Cluster = new Cluster(clientConfiguration);
        using (var bucket = Cluster.OpenBucket("bucketpwd", "1234"))
        {
            Console.WriteLine("Bucket Opened");
        }
