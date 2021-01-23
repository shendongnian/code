    var cluster = Cluster.Builder().AddContactPoints("IPAddress").Build();
    var keyspaces = cluster.Metadata.GetKeyspaces();
    foreach (var keyspaceName in keyspaces)
    {
       Console.WriteLine(keyspaceName);
    }
