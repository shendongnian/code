    List<Type> commandTypes Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IBaseCommand).IsAssignableFrom(t)); //Get all the types that derive from your base type
            foreach (Type derivedType in commandTypes)
            {
                if (derivedType.Name == command.ToLower) //Distinguishing by class name is probably not the best solution here, but just to give you the general idea
                {
                     IBaseCommand myCommandInstance = Activator.CreateInstance(derivedType);//Create an instance of the command type
                     myCommandInstance.Execute();//Call the execute method, that knows what to do
                }
            }
        
