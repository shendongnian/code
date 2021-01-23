    var connectionPool = new SingleNodeConnectionPool(node);
    var settings = new ConnectionSettings(connectionPool)
        .BasicAuthentication(username, password)
        .DisableDirectStreaming()
        .PrettyJson();
        //.ThrowExceptions(); <-- This line had to be commented out.
