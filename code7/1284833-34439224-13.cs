    // Assuming you're getting one command per line and one line is fed to this function
    public void ParseCommands(string command)
    {
        string[] tokens = command.Split(" ");
        // tokens[0] is the command name
        object[] parameters = (object[])tokens.Skip(1);//Take everything but the first element (you need to include LINQ for this)
        // Get all the types that derive from your base type
        List<Type> commandTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IBaseCommand).IsAssignableFrom(t));
        foreach (Type derivedType in commandTypes)
        {
            if (derivedType.Name.ToLower == tokens[0].ToLower) 
            /* Here the class name needs to match the commandname; this yould also be a
               static property "Name" that is extracted via reflection from the classes for 
               instance, or you put all your commands in a Dictionary<String, Type> and lookup 
               tokens[0] in the Dictionary */
            {
                // Create an instance of the command type
                IBaseCommand myCommandInstance = Activator.CreateInstance(derivedType);
                myCommandInstance.parameters = parameters;
                myCommandInstance.Execute(); // Call the execute method, that knows what to do
                     break;
            }
        }   
    }
