        static void Main(string[] args)
        {
            Salutation hello = new Salutation();
            hello.OtherParty = "World";
            hello.GreetingDelegate = new AddressDelegate(HelloSayer);
     
            hello.GreetingDelegate(hello.OtherParty);
            Console.ReadKey();
        }
        public delegate void AddressDelegate(string otherParty);
        private static void HelloSayer(string otherParty)
        {
            Console.WriteLine(string.Format("Hello, {0}!", otherParty));
        }
