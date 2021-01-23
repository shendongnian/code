    public class MappingSearchSchemaFactory : ISearchSchemaFactory
    {
        public MappingSearchSchemaFactory(Dictionary<Type, ISearch<ISchema>> mapping)
        {
            Mapping = mapping;
        }
    
        ISearch<ISchema> GetSearch(Type schemaType)
        {
            ISearch<ISchema> result;
            if(!Mapping.TryGetValue(schemaType, out result)
            {
                //Some logging or throwing exception behavior - depends what you want
            }
            return result;
        }
        public Dictionary<Type, ISearch<ISchema>> Mapping { get; set; }
    }
