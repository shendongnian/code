    public sealed class KnownModelConverter : IModelConverter<IModel>
    {
        private static readonly Dictionary<ModelTypes, IModelConverter<IModel>>
            = new Dictionary<ModelTypes, IModelConverter<IModel>>
        {
            { ModelTypes.TypeA, new DelegatingConverter<ModelA>(new ModelAConverter()) },
            { ModelTypes.TypeB, new DelegatingConverter<ModelB>(new ModelBConverter()) },
            { ModelTypes.TypeC, new DelegatingConverter<ModelC>(new ModelCConverter()) },
        };
        public byte[] ToBytes(IModel model)
        {
            // Here is the delegation..
            return _modelConverters[model.ModelType].ToBytes(model);
        }
    }
