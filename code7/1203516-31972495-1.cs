    class Program
    {
        public void Run()
        {
            int age = GetAge();
            int number = GetNumber();
            GetName(age, number);
        }
        public int GetAge(){
            string age;
            Console.WriteLine(" And enter age: ");
            age = Console.ReadLine();
            return int.Parse(x); // or TryParse and loop until the parse succeeds
        }
        public int GetNumber(){
            string number;
            Console.WriteLine(" And favorite number: ");
            number = Console.ReadLine();
            return int.Parse(number); // or TryParse and loop until the parse succeeds
        }
        public void Name(int x, int y)
        {
            Console.WriteLine("Enter your name: ");
            string test = Console.ReadLine();
            Console.WriteLine("Hi " + test);
        }
        static void Main(string[] args) {
            new Program().Run();
            Console.ReadLine();
        }
    }
