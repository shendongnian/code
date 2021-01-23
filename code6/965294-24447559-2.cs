    public class Book
    {
        public string Title { get; set; }
        public Isbn isbn { get; set; }
    }
    string json1 = @"{Title:""Title 1"", isbn:{groupCode:1,publisherCode:2,titleCode:3,checkCode:4}}";
    string json2 = @"{Title:""Title 2"", isbn:""1-2-3-4""}";
    var book1 = JsonConvert.DeserializeObject<Book>(json1, new IsbnConverter());
    var book2 = JsonConvert.DeserializeObject<Book>(json2, new IsbnConverter());
