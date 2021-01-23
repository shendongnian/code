    public interface IMovable
    {
        void Move(int direction, int speed);
    }
    
    public static MovableExtensions
    {
        public static void Move(this IMovable movable)
        {
            movable.Move(90, 100);
        }
    }
