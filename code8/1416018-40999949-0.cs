    var endpointConfiguration = new EndpointConfiguration("MyEndpoint");
    var fullPath = Assembly.GetAssembly(typeof(ServiceMain)).Location;
    var directory = new DirectoryInfo(Path.GetDirectoryName(fullPath));
    var files = directory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
    var excludedFiles = new List<string>();
    foreach (var file in files) {
        if (!file.Name.Contains("NServiceBus") && !file.Name.Contains("Messages")) {
            excludedFiles.Add(file.Name);      
        }
    }
    endpointConfiguration.ExcludeAssemblies(excludedFiles.ToArray());
