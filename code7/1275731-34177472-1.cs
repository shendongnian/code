    public class GoodClass
    {
        private readonly IClock clock;
        public GoodClass(IClock clock)
        {
            this.clock = clock;
        }
        public bool IsIt2016Yet()
        {
            var now = clock.Now;
            return now.InUtc().Year >= 2016;
        }
    }
