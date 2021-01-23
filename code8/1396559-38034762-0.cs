    public class MultiCommand
    {
        private System.Collections.Generic.List<ICommand> list;
        public List<ICommand> Commands { get { return list; } }
        public CommandContext SharedContext { get; set; }
       
        public MultiCommand() { }
        public MultiCommand(System.Collections.Generic.List<ICommand> list)
        {
            this.list = list;
            //Hook up listener for new Command CTX from other tasks
            XEvents.CommandCTX += OnCommandCTX;
        }
        private void OnCommandCTX(object sender, CommandContext e)
        {
            //Some other task finished, update SharedContext
            SharedContext = e;
        }
        public MultiCommand Add(ICommand cc)
        {
            list.Add(cc);
            return this;
        }
        internal void Execute()
        {
            list.ForEach(cmd =>
            {
                cmd.Execute(SharedContext);
            });
        }
        public static MultiCommand New()
        {
            return new MultiCommand();
        }
    }
