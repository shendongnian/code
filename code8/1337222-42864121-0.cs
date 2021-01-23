    string location = Assembly.GetExecutingAssembly().Location;
    if (location != null)
    {
        string config = Path.Combine(Directory.GetParent(location).FullName, "Config.xml"));
    }
