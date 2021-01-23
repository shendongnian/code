    var assembly = Assembly.GetExecutingAssembly(); //or whatever else
            var types =
                from t in assembly.GetTypes()
                from i in t.GetInterfaces()
                where i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IFoo<,>))
                select new 
                {
                    Type = t,
                    Args = i.GetGenericArguments().ToList()
                };
            foreach (var item in types)
            {
                Console.WriteLine("Class {0} implements with {1}, {2}", item.Type.Name, item.Args[0].Name, item.Args[1].Name);
            }
