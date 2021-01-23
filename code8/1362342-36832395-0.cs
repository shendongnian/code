    public class World { }
    public class Wakeup : World
    {
        public void MethodA(string a)
        {
            Console.WriteLine("Wakeup World");
        }
    }
    public class Hello : World
    {
        public void MethodB()
        {
            Wakeup p = new Wakeup();
            p.MethodA("Dsa");
        }
    }
