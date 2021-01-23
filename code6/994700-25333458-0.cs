    class Shelf
    {
        List<Book> books = new ArrayList<Book>();
        public void Program()
        {
            int numberOfBooks;
            Console.WriteLine("How many books are you adding.");
            numberOfBooks = int.Parse(Console.ReadLine());
            for(int x = 0; x <= numberOfBooks; x++)
            {
                AddBook(); 
            }
        }
    
        public void AddBook()
        {
            string bookTitle;
            Console.WriteLine("Enter title.");
            bookTitle = Console.ReadLine();
            books.Add(new Book(bookTitle));
        }
    }
    class Book
    {
        private string title;
    
        public Book(string _title)
        {
             title = _title;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    
    }
