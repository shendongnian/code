    var assemblyPath = Assembly.GetEntryAssembly().Location;
    var pathsToExclude = new[] { assemblyPath };
    string a = System.IO.Path.GetDirectoryName(assemblyPath);
    foreach (var file in Directory.EnumerateFiles(a).Except(pathsToExclude))
        File.Delete(file);
