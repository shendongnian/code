    public abstract class Command
    {
        protected Command(string name);
        public string Name { get; }
        public abstract void Execute(ArgumentEnumerator args);
    }
