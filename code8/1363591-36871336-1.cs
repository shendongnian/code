    public class Bird
    {     
        public virtual void Fly(int height);   
    }
    public class Penguin : Bird
    {
        public virtual void Swim(int depth);
    }
    public static class BirdExtensions
    {
        public static void Fly(this Bird bird)
        {
        }
    }
