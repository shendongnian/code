    // Get all the types that derive from your base type
    List<Type> commandTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => typeof(IBaseCommand).IsAssignableFrom(t));
    foreach (Type derivedType in commandTypes)
    {
        // Distinguishing by class name is probably not the best solution here, but just to give you the general idea
        if (derivedType.Name == command.ToLower) 
        {
            // Create an instance of the command type
            IBaseCommand myCommandInstance = Activator.CreateInstance(derivedType);
            //Call the execute method, that knows what to do
            myCommandInstance.Execute();
        }
    }
        
