    public class Configuration1Processor : ProcessorBase
    {
        public Configuration1Processor(IProcessor successor)
            : base(successor) { }
        public override bool InnerProcess(ProcessRequest request)
        {
            var values = JsonConvert.DeserializeObject<IEnumerable<ConfigData>>(request.Value);
            if (routingConfigurationData.Any())
            {
                return true;
            }
            return false;
        }
        public override bool IsResponsible(ConfigType type)
        {
            return type == ConfigType.Configuration1;
        }
    }
    public class Configuration2Processor : ProcessorBase
    {
        public Configuration2Processor(IProcessor successor)
            : base(successor) { }
        public override bool InnerProcess(ProcessRequest request)
        {
            // here goes the business logic
            return false;
        }
        public override bool IsResponsible(ConfigType type)
        {
            return type == ConfigType.Configuration2;
        }
    }
