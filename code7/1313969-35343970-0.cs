    string @namespace = "ReflectionNamespaceTest.Models";
    string[] Assemblies = new string[] {
        "ReflectionNamespaceTest.Models",
        "ReflectionNamespaceTest" 
    };
    foreach (var a in Assemblies)
    {
        Assembly loadedAss = Assembly.Load(a);
        var q = from t in loadedAss.GetTypes()
                where t.IsClass && t.Namespace.EndsWith("Models")
                select t;
        q.ToList().ForEach(t => 
            //Register the service here
            Console.WriteLine(t.Name)
        );
    }
