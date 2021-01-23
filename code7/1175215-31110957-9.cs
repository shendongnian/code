    public interface IValidatorFactory
    {
        Dictionary<Type,IValidatorCommand> Commands { get; }
    }
    public class ValidatorFactory : IValidatorFactory
    {
        private static Dictionary<Type,IValidatorCommand> _commands = new Dictionary<Type, IValidatorCommand>();
        public ValidatorFactory() { }        
        public Dictionary<Type, IValidatorCommand> Commands
        {
            get
            {
                return _commands;
            }
        }
        private static void LoadCommand()
        {
            // Here we need to use little Dependency Injection principles and
            // populate our implementations from a XML File dynamically
            // at runtime. For demo, I am passing null in place of UnitOfWork
            _commands.Add(typeof(IUniqueEmailCommand), new UniqueEmail(null));
            _commands.Add(typeof(IEmailFormatCommand), new EmailFormat(null));
        }
        public static IValidatorCommand GetCommand(Type validatetype)
        {
            if (_commands.Count == 0)
                LoadCommand();            
            var command = _commands.FirstOrDefault(p => p.Key == validatetype);
            return command.Value ?? null;
        }
    }
