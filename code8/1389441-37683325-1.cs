    public class Program {
        static void Main(string[] args) {
            TestStuff(1);
            TestStuff(2);
            TestStuff(3);
            Console.ReadKey();
        }
        [Trace("itemId: {0}")]
        static void TestStuff(int itemId) {
            Console.WriteLine("Inside TestStuff: " + itemId);
            if (itemId == 3)
                throw new Exception("Test exception");
        }
    }
