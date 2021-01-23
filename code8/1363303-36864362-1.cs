    public abstract class Metal
    {
        protected Metals MetalType { get; private set; }
        protected Metal(Metals metal)
        {
            MetalType = metal;
        }
    }
    public class Gold : Metal
    {
        public Gold() : base(Metals.Gold)
        {
        }
    }
