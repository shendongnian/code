    public sealed class DelegateCommand : Command
    {
        public DelegateCommand(Delegate method);
        public Delegate Method { get; }
        public override void Execute(ArgumentEnumerator args);
    }
