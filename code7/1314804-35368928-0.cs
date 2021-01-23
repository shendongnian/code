    public class Dog : Animal, IBarkable
    {
        public void IBarkable.Bark() { Console.WriteLine("Bark"); }
    }
    public class RobotDog : Robot, IBarkable
    {
        public void IBarkable.Bark() { Console.WriteLine("Bark"); }
    }
