    public interface IMovable
    {
        void Move();
    }
    public class Truck : IMovable
    {
        public void Move()
        {
            Console.Write("moving");
        }
    }
    public class NoisyMovable : IMovable //1.Implement same interface
    {
        private IMovable movable;
        public NoisyMovable(IMovable movable)//2.Wrap same interface
        {
            this.movable = movable;
        }
        public void Move()
        {
            Console.Write("Make noise");
        }
    }
