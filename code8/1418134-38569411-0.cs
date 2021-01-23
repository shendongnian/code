    class Program
    {
        static void Main(string[] args)
        {
            Bear[] bears = new Bear[3];
            Animal[] animals = bears;
            animals[0] = new Camel(); //will throw on runtime
        }
    }
    public abstract class Animal { }
    public class Camel : Animal { }
    public class Bear : Animal { }
