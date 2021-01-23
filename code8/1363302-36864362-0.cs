    public abstract class Metal
    {
        private readonly Metals _metal;
        protected Metal(Metals metal)
        {
            _metal = metal;
        }
    }
    public class Gold : Metal
    {
        public Gold() : base(Metals.Gold)
        {
        }
    }
