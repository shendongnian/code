    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie();
            int x = 0;
            while (x < 1)
            {
                movie.optionMenu(); Console.Write("Do you want to exit?");
                string response = Console.ReadLine();
                if (response == "Y") { x = 1; }
            }
            Console.Read();
        }
    }
    
    class Movie
    {
        public List<string> movieTitles { get; set; }
    
        public Movie()
        {
            movieTitles = new List<string>();
        }
    
        public void optionMenu()
        {
            Console.Write("(a)LIST MOVIES|(b)ADD Movie|(c)RANDOM MOVIE");
            string ui = Console.ReadLine();
            if (ui == "a") { printNames(); }
            else if (ui == "b") { addMovie(); }
            else if (ui == "c") { randomPickMovie(); }
            else { optionMenu(); }
        }
    
        public void printNames()
        {
            Console.WriteLine("Movies in your list...");
            for (int i = 0; i < movieTitles.Count; i++)
            {
                Console.WriteLine("\t-" + movieTitles[i]);
            }
        }
    
        public void addMovie()
        {
            Console.WriteLine("Enter a title:");
            string newTitle = Console.ReadLine();
            if (newTitle != "")
            {
                movieTitles.Add(newTitle);
                Console.WriteLine("New movie successfully added!");
            }
            else
            {
                Console.WriteLine("Cannot add empty movie. Add movie failed.");
            }
        }
    
        public void randomPickMovie()
        {
            if (movieTitles.Count != 0)
            {
                Random r = new Random();
                int random = r.Next(0, movieTitles.Count - 1);
    
                Console.WriteLine(movieTitles[random]);
            }
            else { Console.WriteLine("Movie list is empty."); }
        }
    }
