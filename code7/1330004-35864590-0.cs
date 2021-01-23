    public class StuffExecuter    
    {
        private readonly IRepository _repository;
        
        public StuffExecuter(IRepository repository)
        {
            _repository = repository;
        }
        public bool CanExecute(BusinessObject obj)
        {
            _repository.Add(obj.UserName, new EArgument
            {
                Name = obj.Name
            });
        }
    }
