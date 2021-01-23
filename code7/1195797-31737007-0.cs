    public static class MapperFactory
    {
       public static MappingEngine NormalMapper()
       {
           var normalConfig = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
           normalConfig.CreateMap<Invoice, InvoiceModel>();
           normalConfig.CreateMap<InvoiceItem, InvoiceItemModel>();
           
           var normalMapper = new MappingEngine(normalConfig);
           return normalMapper;
       }
        public static MappingEngine FlatMapper()
       {
            var flatConfig = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            flatConfig.CreateMap<Invoice, InvoiceModel>()
            .ForMember(m => m.Items, opt => opt.Ignore());
            flatConfig.CreateMap<InvoiceItem, InvoiceItemModel>();
            
            var flatMapper = new MappingEngine(flatConfig);
            return flatMapper;
       }
    }
