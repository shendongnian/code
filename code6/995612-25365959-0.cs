    private readonly List<Book> books = new List<Book>();
    public void AddBooks()
    {
        Console.WriteLine("How many books would you like to add?");
        int count = int.Parse(Console.ReadLine());
        // Note change from <= to <
        for(int x = 0; x < count; x++)
        {
            Console.WriteLine("Enter Title.");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Author.");
            string author = Console.ReadLine();
            books.Add(new Book(title, author));
        }
    }
