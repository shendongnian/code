    using (var reader = new StreamReader("XMLFile1.xml"))
    {
        var serializer = new XmlSerializer(typeof(Applications));
        var applications = (Applications)serializer.Deserialize(reader);
        Console.WriteLine("AccessibleApplications:");
        foreach (var app in applications.AccessibleApplications)
        {
            Console.WriteLine(app.Value);
        }
        Console.WriteLine();
        Console.WriteLine("EligibleApplications:");
        foreach (var app in applications.EligibleApplications)
        {
            Console.WriteLine(app.Value);
        }
    }
