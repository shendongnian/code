    AllClasses.FromLoadedAssemblies()
        .Where(x => (x.IsPublic == true) &&
        (x.GetInterfaces().Any() == true) &&
        (x.IsAbstract == false) &&
        (x.IsClass == true) &&
        x.Namespace == "Company.Project.Data.DA.NW" )
