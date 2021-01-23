    public DelegatingConverter()
    {
        _modelConverters = new Dictionary<ModelTypes, IModelConverter<IModel>>
        {
            {ModelTypes.TypeA, (IModelConverter<IModel>)new ModelAConverter()},
            {ModelTypes.TypeB, (IModelConverter<IModel>)new ModelBConverter()},
            {ModelTypes.TypeC, (IModelConverter<IModel>)new ModelCConverter()}
        };
    }
