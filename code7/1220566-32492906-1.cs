    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    assembly.GetManifestResourceNames()
            .Where(x => x.EndsWith("pp.png")) //Comment this line to find all resource names
            .ToList()
            .ForEach(resource =>
            {
                MessageBox.Show(resource);
            });
