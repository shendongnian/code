    public T CreateBaseModel<T>(params object[] args) where T : BaseModel
    {
        T model = (T)Activator.CreateInstance(typeof(T), args);
        model.foo = "foo";
        return model;
    }
    HomeIndexViewModel model = CreateBaseModel<HomeIndexViewModel>(param1, param2, etc);
