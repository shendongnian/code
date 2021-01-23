    cfg.CreateMap(typeof(NodeDto<>), typeof(NodeModel<>));
    cfg.CreateMap(typeof(NodeDto<>), typeof(INodeModel<>))
        .ConvertUsing(typeof(NodeModelConverter<>));
    cfg.CreateMap(typeof(INodeModel<>), typeof(NodeModel<>));
    public class NodeModelConverter<T> :
        ITypeConverter<NodeModel<T>, INodeModel<T>> where T : struct
    {
        public INodeModel<T> Convert(NodeModel<T> source, ResolutionContext context)
             => new NodeModelImpl {ID = source.ID, Name = source.Name};
        private class NodeModelImpl : INodeModel<T>
        {
            public T? ID { get; set; }
            public string Name { get; set; }
            object INodeModel.ID
            {
                get { return ID; }
                set { ID = (T?) value; }
            }
        }
    }
