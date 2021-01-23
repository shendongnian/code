    public abstract class NHibernateInitializer : IDomainMapper
    {
        protected Configuration Configure;
        private ISessionFactory _sessionFactory;
        private readonly ModelMapper _mapper = new ModelMapper();
        private Assembly _mappingAssembly;
        private readonly String _mappingAssemblyName;
        private readonly String _connectionString;
        protected NHibernateInitializer(String connectionString, String mappingAssemblyName)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString", "connectionString is empty.");
            if (String.IsNullOrWhiteSpace(mappingAssemblyName))
                throw new ArgumentNullException("mappingAssemblyName", "mappingAssemblyName is empty.");
            _mappingAssemblyName = mappingAssemblyName;
            _connectionString = connectionString;
        }
        public ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory ?? (_sessionFactory = Configure.BuildSessionFactory());
            }
        }
        private Assembly MappingAssembly
        {
            get
            {
                return _mappingAssembly ?? (_mappingAssembly = Assembly.Load(_mappingAssemblyName));
            }
        }
        public void Initialize()
        {
            Configure = new Configuration();
            Configure.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { new EventListener() };
            Configure.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new EventListener() };
            Configure.SessionFactoryName(System.Configuration.ConfigurationManager.AppSettings["SessionFactoryName"]);
            Configure.DataBaseIntegration(db =>
                                          {
                                              db.Dialect<MsSql2008Dialect>();
                                              db.Driver<SqlClientDriver>();
                                              db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                                              db.IsolationLevel = IsolationLevel.ReadCommitted;
                                              db.ConnectionString = _connectionString;
                                              db.BatchSize = 20;
                                              db.Timeout = 10;
                                              db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
                                          });
            Configure.SessionFactory().GenerateStatistics();
            Map();
        }
        public virtual void InitializeAudit()
        {
            var enversConf = new Envers.Configuration.Fluent.FluentConfiguration();
            enversConf.Audit(GetDomainEntities());
            Configure.IntegrateWithEnvers(enversConf);
        }
        public void CreateSchema()
        {
            new SchemaExport(Configure).Create(false, true);
        }
        public void DropSchema()
        {
            new SchemaExport(Configure).Drop(false, true);
        }
        private void Map()
        {
            _mapper.AddMappings(MappingAssembly.GetExportedTypes());
            Configure.AddDeserializedMapping(_mapper.CompileMappingForAllExplicitlyAddedEntities(), "MyWholeDomain");
        }
        public HbmMapping HbmMapping
        {
            get { return _mapper.CompileMappingFor(MappingAssembly.GetExportedTypes()); }
        }
        public IList<HbmMapping> HbmMappings
        {
            get { return _mapper.CompileMappingForEach(MappingAssembly.GetExportedTypes()).ToList(); }
        }
        /// <summary>
        /// Gets the domain entities.
        /// </summary>
        /// <returns></returns>
        /// <remarks>by default anything that derives from EntityBase and isn't abstract or generic</remarks>
        protected virtual IEnumerable<System.Type> GetDomainEntities()
        {
            List<System.Type> domainEntities = (from t in MappingAssembly.GetExportedTypes()
                                                where typeof(EntityBase<Guid>).IsAssignableFrom(t)
                                                && (!t.IsGenericType || !t.IsAbstract)
                                                select t
                                               ).ToList();
            return domainEntities;
        }
    }
