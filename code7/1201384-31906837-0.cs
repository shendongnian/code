    public class Column
        {
            public string C1 { get; set; }
            public string C2 { get; set; }
            public Column2 C3 { get; set; }
        }
    
        public class Column2
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
 
    var col2 = new Column2 { Id = 12, Name = "John Doe" };
    
                var column = new Column
                {
                    C1 = "Some text",
                    C2 = "22",
                    C3 = col2
                };
                Console.WriteLine(JsonConvert.SerializeObject(column));
