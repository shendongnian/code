    class Program
    {
        static void Main(string[] args)
        {     
            List<EnteredUser> _names = new List<EnteredUser>();
            Console.WriteLine("How many users would you like to enter? ");
            int _numberOfLoops = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < _numberOfLoops; i++)
            {
                var newUser = new EnteredUser() { id = i };
                Console.WriteLine("Please enter your name ");
                newUser.Name = Console.ReadLine();
                Console.WriteLine("Please enter your score");
                newUser.score = Convert.ToInt32(Console.ReadLine());
                _names.Add(newUser);
            }
            foreach (var item in _names)
            {
                Console.WriteLine("Name: {0} - score: {1}", item.Name, item.score);
            }
            Console.ReadLine();
        }
    }
    class EnteredUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int score { get; set; }
    }
