      class Shelf
    {
        public void Program()
        {
            
            int bookAmount;
    
            Console.WriteLine("How many books are you adding.");
            bookAmount = int.Parse(Console.ReadLine());
            //book is deleted
            for(int x = 0; x <= bookAmount; x++)
            {
                AddBook();//parameter was deleted and aff in function 
            }
        }
    List<Book> bookTitles = new List<Book>();  //collection create generally in class like fields 
    
        public void AddBook()
        {
            Book book = new Book();
            string bookTitle;
    
            Console.WriteLine("Enter title.");
            Book.Title = Console.ReadLine();
            bookTitles.Add(book); //add book to colection
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
