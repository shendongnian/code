    public class Class1 : BaseClass
    {
        private readonly ILog logger;
        public Class1(ICommand command, ILog logger)
            : base(command)
        {
            this.logger = logger;
        }
        public override void Do()
        {
            Console.Write(1);
            CallNext();
        }
    }
