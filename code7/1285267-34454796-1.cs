      var alltypes=AppDomain.CurrentDomain.GetAssemblies().SelectMany(a=>a.GetTypes()); //change "AppDomain.CurrentDomain.GetAssemblies()" for your assemblies collection
      var q = from t in alltypes
              where t.IsInterface 
              let classes = alltypes.Where(s => s.IsClass && t.IsAssignableFrom(s))
              where classes.Count() > 0 
              select new { Interface=t,Classes=classes};
