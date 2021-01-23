    private static MetadataReference FromType(Type type)
    {
        var path = type.Assembly.Location;
        return MetadataReference.CreateFromFile(path, documentation: GetDocumentationProvider(path));
    }
    
    private static string GetReferenceAssembliesPath()
    {
        var programFiles =
            Environment.GetFolderPath(Environment.Is64BitOperatingSystem
                ? Environment.SpecialFolder.ProgramFilesX86
                : Environment.SpecialFolder.ProgramFiles);
        var path = Path.Combine(programFiles, @"Reference Assemblies\Microsoft\Framework\.NETFramework");
        if (Directory.Exists(path))
        {
            var directories = Directory.EnumerateDirectories(path).OrderByDescending(Path.GetFileName);
            return directories.FirstOrDefault();
        }
        return null;
    }
    
    private static DocumentationProvider GetDocumentationProvider(string location)
    {
        var referenceLocation = Path.ChangeExtension(location, "xml");
        if (File.Exists(referenceLocation))
        {
            return GetXmlDocumentationProvider(referenceLocation);
        }
        var referenceAssembliesPath = GetReferenceAssembliesPath();
        if (referenceAssembliesPath != null)
        {
            var fileName = Path.GetFileName(location);
            referenceLocation = Path.ChangeExtension(Path.Combine(referenceAssembliesPath, fileName), "xml");
            if (File.Exists(referenceLocation))
            {
                return GetXmlDocumentationProvider(referenceLocation);
            }
        }
        return null;
    }
    
    private static DocumentationProvider GetXmlDocumentationProvider(string location)
    {
        return (DocumentationProvider)Activator.CreateInstance(Type.GetType(
            "Microsoft.CodeAnalysis.FileBasedXmlDocumentationProvider, Microsoft.CodeAnalysis.Workspaces.Desktop"),
            location);
    }
