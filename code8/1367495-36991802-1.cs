    class Program
    {
        static void Main(string[] args)
        {
            var one = new One();
            var two = new Two();
            Thread.Sleep(1000);
            Console.WriteLine(one.Time);
            Console.WriteLine(two.Time);
            Thread.Sleep(1000);
            Console.WriteLine(one.Time); // this doesn't change
            Console.WriteLine(two.Time); // this will change
            Console.ReadKey();
        }
    }
    
    public class One
    {
        public DateTime Time { get; } = DateTime.Now;
    }
    public class Two
    {
        public DateTime Time => DateTime.Now;
    }
With the auto-property initalizer, it will evaluate DateTime.Now in the constructor and store the result in a backing field. The value of that field is then returned when accessed through the getter.
On the other hand, the expression bodied getter is going to evaluate DateTime.Now everytime it is accessed. Depending on your situation you may want one or the other.
