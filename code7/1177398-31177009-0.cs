    void Main()
    {
    	var test = JsonConvert.DeserializeObject<Root>("{\"rows\":[{\"id\":\"232333\",\"name\":\"nam\"},{\"id\":\"3434444\",\"name\":\"2ndName\"}]}");
    
    	Console.WriteLine(test.rows[0].id); // prints 232333
    }
    
    public class Customer
    {
        public int id { get; set; }
    }
    
    public class Root
    {
        public List<Customer> rows { get; set; }
    }
