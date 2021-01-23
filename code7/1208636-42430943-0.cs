    ABCClass : ObjectContext {
    public const string ConnectionString = "name=FDDEntities";
    public const string ContainerName = "FDDEntities";
    public ABCClass() : base(ConnectionString, ContainerName) { }
    private ObjectSet<FDDEntity> _FDDEntity;
    //Objects Creation
    public ObjectSet<FDDEntity> FDDEntities
        {
            get
            {
                _FDDEntity = base.CreateObjectSet<FDDEntity>("FDDEntities");
                return _FDDEntity;
            }
        }
    }
