    public class CommandHandler : ICommandHandler<Command1>
    {
        private readonly IEnumerable<IService> _services;
        public CommandHandler(IService[] services)
        {
            _servies = services;
        }
        public void Handle(Command1 command)
        {
            var service = _services.Single(s => s.Type == command.Service);
            service.DoWork();
        }
    }
