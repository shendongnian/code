    public class YourClass
    {
        private readonly IEnumerable<IStrategy> _strategies;
        // Inject the strategies using DI container or build them manually
        public YourClass(IEnumerable<IStrategy> strategies)
        {
            _strategies = strategies;
        }
        public void YourMethod()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int k = 0; k < 5; k++)
                {
                    _strategies.Where(s=>s.IsApplicable(this))
                        .ToList()
                        .ForEach(s => s.Apply(this));
                }
            }
        }
    }
