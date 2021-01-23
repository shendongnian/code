    var assembly = GetType().GetTypeInfo().Assembly;
    using (var stream = assembly.GetManifestResourceStream("YourNativeAssembly.FolderYouPutTheFileIn.filename.txt"))
    using (var reader = new StreamReader(stream))
    {
        string contents = reader.ReadToEnd();
    }
