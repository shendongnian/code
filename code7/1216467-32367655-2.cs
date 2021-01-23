    class Program
    {
        static void Main(string[] args)
        {
            ...
        }
       
        static void optionMenu()
        {
            List<string> movieTitles = new List<string>(); 
            string ui = Console.ReadLine();
            if (ui == "a") { printNames(movieTitles); }
            else if (ui == "b") { addMovie(movieTitles); }
            else if (ui == "b") { randomPickMovie(movieTitles); }
            else { optionMenu(); }
        }
    
        static void printNames(IReadOnlyList<string> movieTitles)
        {
            Console.WriteLine("Movies in your list...");
            for (int i = 0; i < movieTitles.Count;i++)
            {
                Console.WriteLine("\t-" + movieTitles[i]);
            }
        } 
    
        static void addMovie(List<string> movieTitles)
        {
            movieTitles.Add(newTitle);
        }
    
        static void randomPickMovie(List<string> movieTitles)
        {
            ...
        }
    }
