    public class UnitOfWorkManager<T>
    {
        private readonly IDataRepository _dataRepository;
        private List<T> _unitOfWorkItems;
    
        public UnitOfWorkManager(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
    
        public void AddUnitOfWork(IUnitOfWork<T> unitOfWork)
        {
            this._unitOfWorkItems.Add(unitOfWork);
        }
    
        public void Execute()
        {
            WorkerItem previous = null;
            foreach (var item in _unitOfWorkItems)
            {
                var repoItem = _dataRepository.Get(item.Id);
                var input = new WorkerItem(item.Id, repoItem.Name, previous);
                previous = input;
            }
        }
    }
    
    public interface IUnitOfWork<T> 
        where T: WorkerItem, new()
    {
        string Id { get; }
        void Execute(T input);
    }
    
    public class WorkerItem
    {
        public WorkerItem(string id, string name, WorkerItem previous)
        {
            this.Name = name;
            this.Id = id;
            this.Previous = previous;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public WorkerItem Previous { get; private set; }
    }
