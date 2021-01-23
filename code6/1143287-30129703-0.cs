    var searchType = typeof(MyBaseClass<MyScraper, MyElance>);
                var types =
                    AppDomain.CurrentDomain.GetAssemblies()
                        // For search only on assemblies where could exsist this types
                        .Where(a => a.GetName().Name == searchType.Assembly.GetName().Name || a.GetReferencedAssemblies().Any(n => n.Name == searchType.Assembly.GetName().Name))
                        .Where(t => !t.IsAbstract && !t.IsInterface)
                        .Select(t => t.GetTypes().Where(a => searchType.IsAssignableFrom(a)))
                        .SelectMany(a => a);
