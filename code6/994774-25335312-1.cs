    public void Program()
    {
        List<string> bookTitle = new List<string>();
        List<string> bookAuthor = new List<string>();
        List<int> bookPageCount = new List<int>();
        List<int> bookWordCount = new List<int>();
    
        while (true)
        {
            Console.WriteLine("1. Add Book.");
            Console.WriteLine("2. List Book.");
            Console.WriteLine("3. Quit.");
    
            int userEntry = int.Parse(Console.ReadLine());
            switch (userEntry)
            {
                case 1:
                    AddBook(bookTitle, bookAuthor, bookPageCount, bookWordCount);
                    break;
                case 2:
                    ListBook(bookTitle, bookAuthor, bookPageCount, bookWordCount);
                    break;
                case 3:
                    Environment.Exit(1);
                    return;
            }
        }
    }
