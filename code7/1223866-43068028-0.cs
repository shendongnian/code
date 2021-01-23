     class ListOperations
    {
        public static void Main(string[] args)
        {
            List<Book> books = new List<Book>
           {
               new Book { Name="book1",ISBN= 554654,Category= "Mathematics",Price=12.45,Index=1},
               new Book { Name="book2",ISBN= 454654, Category="English", Price=-6.45, Index=3},
               new Book {Name="book3",ISBN= 754654, Category="English", Price=7.45, Index=4 },
               new Book { Name = "book4", ISBN = 854654,Category= "History", Price=8.45,Index= 5 },
               new Book { Name = "book5", ISBN = 154654, Category="Mathematics", Price=17.45, Index=2 },
               new Book { Name = "book6", ISBN = 354654, Category="History", Price=-15.45, Index=6 },
               new Book { Name = "book7", ISBN = 354653, Category="History", Price=0, Index=6 }
            };
            books.Sort((x, y) => x.Price > 0 && y.Price > 0 || x.Price < 0 && y.Price < 0 ? Math.Abs(x.Price).CompareTo(Math.Abs(y.Price)) : -x.Price.CompareTo(y.Price));
        }
        class Book
        {
            public string Name { get; set; }
            public int ISBN { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
            public double Index { get; set; }
            public int RowNum { get; set; }
        }
    }
