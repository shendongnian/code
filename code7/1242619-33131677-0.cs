    public class Enemy
    {
        public virtual void Test()
        {
            Console.WriteLine("enemy");
        }
    }
    public class Ogre: Enemy
    {
        public override void Test()
        {
            Console.WriteLine("ogre");
        }
    }
