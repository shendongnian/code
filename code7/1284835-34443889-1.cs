    public sealed class CommandContext : Command
    {
        public CommandContext(string name);
        public CommandCollection Commands { get; }
        public override void Execute(ArgumentEnumerator args);
    }
    public sealed class CommandCollection : KeyedCollection<string, Command>
    {
        public CommandCollection() 
            : base(StringComparer.OrdinalIgnoreCase) 
        { 
        } 
        protected override string GetKeyForItem(Command item)
        { 
            return item.Name;
        }
 
        public bool TryGetCommand(string name, out Command command)
        { 
            return Dictionary.TryGetValue(name, out command);
        }
    }
