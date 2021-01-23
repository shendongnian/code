    public interface IMovable
    {
        void Move(int direction = 90, int speed = 100);
    }
    public class Ball : IMovable
    {
        // the method you want to implement from interface 
        // MUST same with interface's declaration
        public void Move(int direction = 90, int speed = 100)
        {
            // ...
        }
        public void Play()
        {
            Move();
        }
    }
