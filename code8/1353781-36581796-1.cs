    public static List<string> ListContainer(StartConfig config)
    {
        if (config == null)
            throw new ArgumentNullException("config");
        if (config.BlobClient == null)
            throw new ArgumentException("BlobClient must not be null", "config");
        List<string> container = new List<string>();
        //Get the list of the blob from the above container
        IEnumerable<CloudBlobContainer> containers = config.BlobClient.ListContainers();
        foreach (CloudBlobContainer item in containers)
        {
           container.Add(item.Name);
        }
        //Adding a print statement
        Console.WriteLine(String.Join("\n", container));
        Console.WriteLine("\n");
        return container;
    }
