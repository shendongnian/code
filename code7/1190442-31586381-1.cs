    static void Main(string[] args)
            {
                Books books = new Books() { Customer = "Allan" };
                books.BookList.Add(new Book() { Title = "T1", Selected = true });
                books.BookList.Add(new Book() { Title = "T2", Selected = false });
                books.BookList.Add(new Book() { Title = "T3", Selected = true });
    
                // here you add the filter that used when serialized
                books.RunBeforeSerialization(b => b.Selected == true);
    
                XmlSerializer ser = new XmlSerializer(typeof(Books));
                StringWriter sw = new StringWriter();
                ser.Serialize(sw, books);
    
                Console.WriteLine(sw.ToString());
    
                Console.ReadLine();
    
            }
