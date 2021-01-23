    DirectoryInfo areasFolder = new DirectoryInfo(HostingEnvironment.MapPath(@"~\Areas"));
    FileInfo[] assemblyFiles =
                            areasFolder.EnumerateDirectories()
                                .SelectMany(d => d.EnumerateFiles("*.dll"))
                                .Where(f => f.Name.Contains("MyAppNamespace"))
                                .GroupBy(f => f.Name.Substring(0, f.Name.Length - f.Extension.Length))
                                .Select(g => g.OrderByDescending(f => f.LastWriteTimeUtc).First())
                                .ToArray();
