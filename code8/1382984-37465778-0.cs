    Assembly.GetEntryAssembly()
            .GetTypes()
            .AsEnumerable()
            .Where(type => typeof(Controller).IsAssignableFrom(type))
            .ToList()
            .ForEach(d =>
            {
                var yourAttributes = d.GetCustomAttributes<YourAttribute>();
                // do the stuff
            });
