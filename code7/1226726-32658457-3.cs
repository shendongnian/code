    interface IRepository
    {
        T Get<TModel>(int id);
        T Save<TModel>(TModel model);
        void Delete<TModel>(TModel model);
        void Delete<TModel>(int id);
    }
