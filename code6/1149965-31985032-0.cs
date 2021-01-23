    var settings = new MongoClientSettings
    {
        ClusterConfigurator = cb =>
        {
            var textWriter = TextWriter.Synchronized(new StreamWriter("mylogfile.txt"));
            cb.AddListener(new LogListener(textWriter));
        }
    };
