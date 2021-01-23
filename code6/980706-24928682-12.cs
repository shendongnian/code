    interface IQueryable // My best guess at this. Substitute with the correct definition!
    {
        string Name { get; set; }
    }
    interface IRepository
    {
        IEnumerable<IQueryable> GetAllQueryAble();
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
