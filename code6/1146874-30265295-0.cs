    var convention = new ConventionPack { 
        new IgnoreExtraElementsConvention(true), 
        new IdGeneratorConvention() };
    ConventionRegistry.Register("CubeConventions", convention, x => true);
    public class IdGeneratorConvention : ConventionBase, IPostProcessingConvention
    {
        public void PostProcess(BsonClassMap classMap)
        {
            var idMemberMap = classMap.IdMemberMap;
            if (idMemberMap == null || idMemberMap.IdGenerator != null)
            {
                return;
            }
            idMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
        }
    }
