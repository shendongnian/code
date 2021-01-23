    public class MultiCommand
    {
        private System.Collections.Generic.List<ICommand> list;
        public List<ICommand> Commands { get { return list; } }
        public CommandContext SharedContext { get; set; }
    
        public MultiCommand() { }
        public MultiCommand(System.Collections.Generic.List<ICommand> list)
        {
            this.list = list;
        }
        public MultiCommand Add(ICommand cc)
        {
            list.Add(cc);
            return this;
        }
    
        internal void Execute()
        {
            throw new NotImplementedException();
        }
        public static MultiCommand New()
        {
            return new MultiCommand();
        }
    }
