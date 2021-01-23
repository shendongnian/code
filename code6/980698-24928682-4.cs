    interface IRepository
    {
        string GetAllQueryAble();
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
