        /// <summary>
        /// A base EntityFramework DataContext class
        /// </summary>
        public partial class DataContextBase : DbContext, IDataContext
        {
            /// <summary>
            /// Provides asynchronous locking capabilities
            /// </summary>
            protected readonly AsyncLock _databaseLock = new AsyncLock("DataContext");
        
            public event EventHandler Disposed;
            public event SavedChangesEventHandler SavedChanges;
            public event EntitiesChangedEventHandler EntitiesChanged;
    
            /// <summary>
            /// A dictionary containing all EntityFramework types and properties
            /// </summary>
            private readonly Dictionary<string, List<string>> EntityFrameworkPropertyCache;
    
    
            private ILoggingService _log;
            private IExceptionService _exception;
            private IEnumerable<object> _deletedEntities;
    
            private Dictionary<string, string> _schemaCache;
    
            /// <summary>
            /// A lock that can be awaited for co-ordinating (serialising) access to the DataContext
            /// </summary>
            public AsyncLock DatabaseLock { get { return _databaseLock; } }
    
            /// <summary>
            /// Gets a reference to the underlying ObjectContext
            /// </summary>
            public ObjectContext Context { get { return ((IObjectContextAdapter)this).ObjectContext; } }
            
            /// <summary>
            /// Gets or sets the Command Timeout
            /// </summary>
            public int? CommandTimeout
            {
                get { return Database.CommandTimeout; }
                set
                {
                    Database.CommandTimeout = value;
                    Context.CommandTimeout = value;
                }
            }
    
            /// <summary>
            /// Gets the underlying SqlConnection
            /// </summary>
            public SqlConnection SqlConnection { get { return (SqlConnection) ((EntityConnection) Context.Connection).StoreConnection; } }
    
            /// <summary>
            /// Checks whether we can connect
            /// </summary>
            public bool CanConnect { get { return Database.Exists(); } }
    
            /// <summary>
            /// Gets the Server this DataSource this instance is connected to
            /// </summary>
            public string DataSource { get { return Database.Connection.DataSource; } }
    
            /// <summary>
            /// Gets or sets whether the context Lazyily loads properties on access
            /// </summary>
            public bool LazyLoadingEnabled
            {
                get { return Configuration.LazyLoadingEnabled; }
                set { Configuration.LazyLoadingEnabled = value; }
            }
    
            /// <summary>
            /// Gets or sets whether AutoDetechChanges is Enabled
            /// </summary>
            public bool AutoDetectChangesEnabled
            {
                get { return Configuration.AutoDetectChangesEnabled; }
                set { Configuration.AutoDetectChangesEnabled = value; }
            }
    
            /// <summary>
            /// Gets or sets whether ValidateOnSave is Enabled
            /// </summary>
    
            public bool ValidateOnSaveEnabled
            {
                get { return Configuration.ValidateOnSaveEnabled; }
                set { Configuration.ValidateOnSaveEnabled = value; }
            }
    
            /// <summary>
            /// Gets whether this DataContext is disposed
            /// </summary>
            public bool IsDisposed { get; private set; }
    
            /// <summary>
            /// Gets or sets whether DataContext events are raised
            /// </summary>
            public bool NotificationsBlocked { get; set; }
    
            /// <summary>
            /// Gets all Entities that are Modified
            /// </summary>
            public List<object> ModifiedEntities
            {
                get { return GetObjectStateEntries(EntityState.Modified).Select(e => e.Entity).ToList(); }
            }
    
            /// <summary>
            /// Gets all Entities that are Modified
            /// </summary>
            public List<object> AddedEntities
            {
                get { return GetObjectStateEntries(EntityState.Added).Select(e => e.Entity).ToList(); }
            }
    
            /// <summary>
            /// Gets all Entities that are Modified
            /// </summary>
            public List<object> DeletedEntities
            {
                get { return GetObjectStateEntries(EntityState.Deleted).Select(e => e.Entity).ToList(); }
            }
    
            /*
             * Instantiation
             */
    
            /// <summary>
            /// Constructs a new DataContextBase  
            /// </summary>
            public DataContextBase ()
            {
                EntityFrameworkPropertyCache = Context.GetEntityPropertDictionary();
    
                SavedChanges += OnSavedChanges;
                AddLocalEntityChangedEventHandler();
    
                OnCreated();
            }
    
            /// <summary>
            /// Constructs a new DataContextBase for the specified configuration connection key
            /// </summary>
            /// <param name="connectionKey">The config connection key</param>
            public DataContextBase (string connectionKey)
                : base(connectionKey)
            {
                EntityFrameworkPropertyCache = Context.GetEntityPropertDictionary();
    
                SavedChanges += OnSavedChanges;
                AddLocalEntityChangedEventHandler();
    
                OnCreated();
            }
    
    
            protected virtual void OnCreated()
            {
            }
    }
