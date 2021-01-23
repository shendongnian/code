    class Program
    {
        static void Main(string[] args)
        {
            ...
        }
    
        static List<string> movieTitles = new List<string>(); 
    
        static void optionMenu()
        {
            ...
        }
    
        static void printNames()
        {
            Console.WriteLine("Movies in your list...");
            for (int i = 0; i < movieTitles.Count;i++)
            {
                Console.WriteLine("\t-" + movieTitles[i]);
            }
        } 
    
        static void addMovie()
        {
            movieTitles.Add(newTitle);
        }
    
        static void randomPickMovie()
        {
            ...
        }
    }
