    using System.Resources;
    List<string> _paths = new List<string> { ConfigurationManager.AppSettings["SpanPath"], ConfigurationManager.AppSettings["FrenPath"], ConfigurationManager.AppSettings["RusPath"] };
    using(ResXResourceWriter resourceWriter = new ResXResourceWriter(_paths.ElementAt(0)))
    {
        resourceWriter.AddResource("Key1", "String1");
        resourceWriter.AddResource("Key2", "String2");
        resourceWriter.Generate();
    }
