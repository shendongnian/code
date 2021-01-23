    const string subfolder = "WINFORMSAPP.Resources.SUBFOLDER.";
    var assembly = Assembly.GetExecutingAssembly();
    foreach (var name in assembly.GetManifestResourceNames()) {
        // Skip names outside of your desired subfolder
        if (!name.StartsWith(subfolder)) {
            continue;
        }
        using (Stream input = assembly.GetManifestResourceStream(name))
        using (Stream output = File.Create(path + name.Substring(subfolder.Length))) {
            input.CopyTo(output);
        }
    }
