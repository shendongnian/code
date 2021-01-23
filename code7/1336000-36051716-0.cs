    private static void CreateResourceFile()
    {
        using (ResXResourceWriter writer = new ResXResourceWriter("c:\\temp\\Resource1.resx"))
        {
            writer.AddResource("String 1", "First String");
            writer.AddResource("String 2", "Second String");
            writer.AddResource("String 3", "Third String");
            writer.Generate();
        }
    }
