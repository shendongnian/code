    class Program
    {
        public static void Main()
        {
            String name = "John";
            int age = 30;
            var variable = SomeClass.SomeMethod(name != "bob", age > 50);
            Console.Write(variable);
            Console.ReadKey();
        }
        public class SomeClass
        {
            public static string SomeMethod(bool nameTest, bool ageTest)
            {
                return string.Format("nameTest is {0}, ageTest is {1}", nameTest.ToString(), ageTest.ToString());
            }
        }
    }
