    interface IBreathes()
    {
        void Breathe();
    }
    interface IMoveable()
    {
        void Move(int x, int y);
    }
    
    class Snake : Animal, IBreathes, IMoveable
    {
        void Breathe()
        {
            ...
        }
        
        void Move(int x, int y)
        {
            ...
        }
    }
