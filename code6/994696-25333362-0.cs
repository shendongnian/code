      class Shelf
    {
        public void Program()
        {
            
            int bookAmount;
    
            Console.WriteLine("How many books are you adding.");
            bookAmount = int.Parse(Console.ReadLine());
    
            for(int x = 0; x <= bookAmount; x++)
            {
                AddBook(book); 
            }
        }
    List<Book> bookTitles = new List<Book>(); 
    
        public void AddBook(Book book)
        {
            Book book = new Book();
            string bookTitle;
    
            Console.WriteLine("Enter title.");
            Book.Title = Console.ReadLine();
            bookTitles.Add(book);
        }
    }
    
        class Book
    {
        private string title;
    
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    
    }
