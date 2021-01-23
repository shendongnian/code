    public class Ball : IMovable
    {
        void IMovable.Move(int direction, int speed)
        {
            Debug.WriteLine(direction + "," + speed);
        }
        public void Move(int direction = 20, int speed = 10)
        {
            Debug.WriteLine(direction + ","+ speed);
        }
        public void Play()
        {
            Debug.WriteLine("From interface");
            ((IMovable) this).Move();
            Debug.WriteLine("From this class defaults");
            Move();
        }
    }
