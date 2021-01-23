    public interface IPosition
    {
        void Adjust(Trade newfill)
    }
    public class PositionNTS : IPosition
    {
        public void Adjust(Trade newfill)
        {
             ...
        }
    }
    
    public class Position : IPosition
    {
        private readonly object locker = new object();
    
        public void Adjust(Trade newfill)
        {
            lock (locker)
            {
                ...
            }
        }
    }
