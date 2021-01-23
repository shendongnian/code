    public class ExistAttribute : ValidationAttribute
    {
        //we can inject another error message or use one from resources
        //aint doing it here to keep it simple
        private const string DefaultErrorMessage = "The value has invalid value";
        //use it for validation purpose
        private readonly ExistRepository _repository;
        private readonly string _tableName;
        private readonly string _field;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tableName">Lookup table</param>
        /// <param name="field">Lookup field</param>
        public ExistAttribute(string tableName, string field) : this(tableName, field, DependencyResolver.Current.GetService<ExistRepository>())
        {
        }
        /// <summary>
        /// same thing
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="field"></param>
        /// <param name="repository">but we also inject validation repository here</param>
        public ExistAttribute(string tableName, string field, ExistRepository repository) : base(DefaultErrorMessage)
        {
            _tableName = tableName;
            _field = field;
            _repository = repository;
            
        }
        /// <summary>
        /// checking for existing object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return _repository.Exists(_tableName, _field, value);
        }
    }
