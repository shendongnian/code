    class Program
    {
        static void Main(string[] args)
        {
            optionMenu();
            Console.Read();
        }
    
        static List<string> movieTitles;
    
        static List<string> MovieTitles
        {
            get
            {
                if (movieTitles == null)
                    CreateMoviesList();
    
                return movieTitles;
            }
        }
    
        static void CreateMoviesList()
        {
            movieTitles = new List<string>();
    
            /*list.....
            / movieTitles.Add("Jurassic Park");
            /..........
            /..........
            */
        }
    
        static void optionMenu()
        {
            Console.Write("(a)LIST MOVIES|(b)ADD Movie|(c)RANDOM MOVIE");
            string ui = Console.ReadLine();
            if (ui == "a") { printNames(); }
            else if (ui == "b") { addMovie(); }
            else if (ui == "b") { randomPickMovie(); }
            else { optionMenu(); }
    
        }
        static void printNames()
        {
            Console.WriteLine("Movies in your list...");
            for (int i = 0; i < MovieTitles.Count; i++)
            {
                Console.WriteLine("\t-" + movieTitles[i]);
            }
        }
    
        static void addMovie()
        {
            Console.WriteLine("Enter a title:");
            string newTitle = Console.ReadLine();
            MovieTitles.Add(newTitle);
        }
    
        static void randomPickMovie()
        {
            Random r = new Random();
            int random = r.Next();
    
            Console.WriteLine(MovieTitles[random]);
        }
    }
