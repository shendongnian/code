    interface IRepositoryItem
    {
        string Name { get; }
    }
    interface IRepository
    {
        IEnumerable<IRepositoryItem> GetAllQueryAble();
        void Add(string name, DateTime dateAdded, DateTime lastModifiedDate, bool isDeleted);
    }
    interface ITagRepository: IRepository
    {
        // ...
    }
    interface ICategoryRepository: IRepository
    {
        // ...
    }
    public sealed class Tag: IRepositoryItem
    {
        public string Name
        {
            get
            {
                return "TODO: Implementation";
            }
        }
    }
