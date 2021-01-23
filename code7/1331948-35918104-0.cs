    var myTypes = System.Reflection.Assembly.GetAssembly(typeof(ApplicationIntegration)).GetTypes().Where(d => d.Name == "ApplicationIntegration") .ToList();
    foreach (Type type in myTypes)
    {
        object obj = Activator.CreateInstance(type);
        var actual = obj.CheckIfPropertyIsAnnotated<NotToCrud>("Profiles");
