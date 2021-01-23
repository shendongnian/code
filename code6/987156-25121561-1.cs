    public class MoveCustomerCommandHandler : ICommandHandler<MoveCustomerCommand>
    {
        private readonly DBContext context;
        // Here we simply inject the DbContext, not a factory.
        public MoveCustomerCommandHandler(DbContext context)
        {
            this.context = context;
        }
        public void Handle(MoveCustomerCommand command)
        {
            // write business transaction here.
        }
    }
