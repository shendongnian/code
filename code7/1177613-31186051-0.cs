    interface ICRUDRepo<T> //where T is always a Domain object
    {
        T get(GUid id);
        void Add(T entity);
        void Save(T entity);
     }
    //then it's best (for maintainability) to define a specific interface for each case
    
    interface IProductsRepository:ICRUDRepo<Product>
    {
        //additional methods if needed by the domain use cases only
        //this search the storage for Products matching a certain criteria,
        // then returns a materialized collection of products 
        //which satisfy the given criteria
        IEnumerable<Product> GetProducts(SelectByDate criteria);
     }
