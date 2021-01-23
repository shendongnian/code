    public static Tuple<List<string>,List<string>> ListContainer(StartConfig config)
    {
        if (config != null || config.BlobClient != null)
        {
            config = Program.GetConfig();
        }
        if (config == null)
        {
            throw new ArgumentNullException("config");
        }
        if (config.BlobClient == null)
        {
            throw new ArgumentException("BlobClient must not be null", "config");
        }
        List<string> container = new List<string>();
        //Get the list of the blob from the above container
        IEnumerable<CloudBlobContainer> containers = config.BlobClient.ListContainers();
        foreach (CloudBlobContainer item in containers)
        {
            container.Add(item.Name);
            config.ContainerNames.Add(String.Join("\n", container));
        }
        config.ListContainerData = new Tuple<List<string>, List<string>>(new List<string>(), new List<string>());
        config.ListContainerData.Item2.AddRange(config.ContainerNames);
        config.ListContainerData.Item1.AddRange(container);
        //Adding a print statement
        Console.WriteLine(String.Join("\n", container));
        Console.WriteLine("\n");
        // Console.WriteLine(startConfig.ContainerNames.ToString());
        return config.ListContainerData;
    }
