    string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
    NamespaceManager nm = NamespaceManager.CreateFromConnectionString(connectionString);
    IEnumerable<TopicDescription> topicList=nm.GetTopics();
            foreach(var td in topicList)
            {
                Console.WriteLine(td.Path);
            }
