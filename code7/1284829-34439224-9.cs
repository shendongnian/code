    public void ParseCommands(string command)//Assuming youre getting one command per line and one line is fed to this function
    {
         string[] tokens = command.Split(" ");
         //tokens[0] is the command name
         object[] parameters = (object[])tokens.Skip(1);//Take everything but the first element (you need to include LINQ for this)
         List<Type> commandTypes Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IBaseCommand).IsAssignableFrom(t)); //Get all the types that derive from your base type
            foreach (Type derivedType in commandTypes)
            {
                if (derivedType.Name.ToLower == tokens[0].ToLower) 
                /*Here the class name needs to match the commandname; this yould also be a
                  static property "Name" that is extracted via reflection from the classes for 
                  instance, or you put all your commands in a Dictionary<String, Type> and lookup 
                  tokens[0] in the Dictionary*/
                {
                     IBaseCommand myCommandInstance = Activator.CreateInstance(derivedType);//Create an instance of the command type
                     myCommandInstance.parameters = parameters;
                     myCommandInstance.Execute();//Call the execute method, that knows what to do
                     break;
                }
            }   
    
    }
