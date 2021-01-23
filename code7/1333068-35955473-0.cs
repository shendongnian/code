    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = "namespaceOfAssembly.Folder.MyFile.txt";
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    using (StreamReader reader = new StreamReader(stream))
    {
        string result = reader.ReadToEnd();
    }
