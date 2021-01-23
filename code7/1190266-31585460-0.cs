    public static class TaskMappingEngineFactory
    {
        private static readonly object _lock = new object();
        private static Dictionary<Enums.PortalEnum, MappingEngine> _mappingEngines = new Dictionary<Enums.PortalEnum, MappingEngine>();
        public static MappingEngine GetMappingEngine(TaskBehavior taskBehavior)
        {
            lock (_lock)
            {
                MappingEngine mappingEngine;
                if (!_mappingEngines.TryGetValue(taskBehavior.PortalType, out mappingEngine))
                {
                    ConfigurationStore store = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
                    store.CreateMap<TaskInfoDetail, TaskInfoDetail>()
                        .ForMember(dst => dst.CanExecuteAutomatically, o => o.Condition((Func<TaskInfoDetail,bool>)(src => taskBehavior.AdvancedPropertiesVisible)))
                        .ForMember(dst => dst.CanExecuteManually, o => o.Condition((Func<TaskInfoDetail,bool>)(src => taskBehavior.AdvancedPropertiesVisible)));
                    MappingEngine engine = new MappingEngine(store);
                    _mappingEngines.Add(taskBehavior.PortalType, mappingEngine = engine);
                }
                return mappingEngine;
            }
        }
    }
