    class Program
    {
        static void Main(string[] args)
        {     
            // A List to store our users
            List<EnteredUser> _names = new List<EnteredUser>();
            // Ask how many users to get
            Console.WriteLine("How many users would you like to enter? ");
            // Store number of loops
            int _numberOfLoops = Convert.ToInt32(Console.ReadLine());
            // Loop however many times we said
            for (int i = 0; i < _numberOfLoops; i++)
            {
                // Create a new user object with the loop index as id
                var newUser = new EnteredUser() { id = i };
                // Get users name
                Console.WriteLine("Please enter your name ");
                newUser.Name = Console.ReadLine();
                // Get users score
                Console.WriteLine("Please enter your score");
                newUser.score = Convert.ToInt32(Console.ReadLine());
                // Add user to our list
                _names.Add(newUser);
            }
            // For each user we collected
            foreach (var item in _names)
            {
                // Write their name without break so we get a list
                Console.WriteLine("Name: {0} - score: {1}", item.Name, item.score);
            }
            // Stop
            Console.ReadLine();
        }
    }
    
    /// <summary>
    /// Class to store user detaisl
    /// Easily expanded with more properties
    /// </summary>
    class EnteredUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int score { get; set; }
    }
