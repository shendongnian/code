    Assembly currentAssembly = Assembly.GetExecutingAssembly();
    string initialAssembly = new StackTrace().GetFrames()
                                             .Where(x => x.GetMethod().ReflectedType != null)
                                             .Select(x => x.GetMethod().ReflectedType.Assembly).Distinct()
                                             .Where(x => x.GetReferencedAssemblies().Any(y => y.FullName == currentAssembly.FullName))
                                             .Last()
                                             .FullName;
