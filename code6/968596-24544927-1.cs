    public class Trade
    {
    }
    public class PositionNTS
    {
        public virtual void Adjust(Trade newfill)
        {
        }
    }
    public class Position : PositionNTS
    {
        private readonly object locker = new object();
        public override void Adjust(Trade newfill)
        {
            lock (locker)
            {
                base.Adjust(newfill);
            }
        }
    }
