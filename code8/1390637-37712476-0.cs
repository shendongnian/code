    public class Command
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
    
    
    public class CommandGroup
    {
       public string Name {get;set;}
       public IEnumerable<Commands> Commands {get;set;}
    }
    
    
    
    public class CommandGroupLookup
    {
    
        public CommandGroupLookup()
        {
             //initialize from database or wherever 
        }
    
        private readonly Dictionary<string,CommandGroup> _commandGroup;
        public Command LookupGroup( string lookupCommandGroup )
        {
            return _commandGroup[lookupCommandGroup];
        }
    }
