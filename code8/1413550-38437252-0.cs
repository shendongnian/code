    public class SubService
    {
        private readonly List<IService<IBoBase>> _injectedService;
        public SubService(*IService<IBoBase>* injectedService)**
        {
            _injectedService = new List<IService<IBoBase>>
            {
                injectedService 
            };
        }
    }
