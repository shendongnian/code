    public interface ICommandFactory
    {
        Command1 CreateCommand(Services serviceType);
    }
    public class CommandFactory : ICommandFactory
    {
        private readonly IContext _context;
        public CommandFactory(IContext context)
        {
            _context = context;
        }
        public Command1 CreateCommand(Services serviceType)
        {
            IService service;
            switch(serviceType)
            {
                case Services.Service_One: service = _context.GetInstance<Service1>();
                    break;
                case Services.Service_Two: service = _context.GetInstance<Service2>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("serviceType", serviceType, null);
            }
            
            return new Command1(service);
        }
    }
