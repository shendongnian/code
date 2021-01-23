    var localRepository = new SharedPackageRepository(packagesPath);
    var allAssemblies = localRepository
                .GetPackages()
                .ToArray()
                .SelectMany(p => p.AssemblyReferences.Select(a =>
                {
                    var path = Path.Combine(packagesPath, p.Id + "." + p.Version, a.Path);
                    var aname = AssemblyName.GetAssemblyName(path);
                    return new { key = aname.FullName, value = path };
                }))
                .DistinctBy(i => i.key)
                .ToDictionary(i => i.key, i => i.value);
    AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) =>
            {
                var aname = new AssemblyName(eventArgs.Name);
                if (allAssemblies.ContainsKey(aname.FullName))
                {
                    return Assembly.LoadFile(allAssemblies[aname.FullName]);
                }
                return null;
            };
