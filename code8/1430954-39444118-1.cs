    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("http://openlibrary.org");
            var request = new RestRequest("/api/books?bibkeys=ISBN:0192821474&jscmd=data&format=json", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            Book book = DeserializeAndUnwrap<Book>(content);
            Console.WriteLine(book.title);
            if (book.authors.Any()) Console.WriteLine("By " + book.authors.First().name);
            Console.WriteLine(book.number_of_pages + " pages");
            Console.WriteLine("Published " + book.publish_date);
        }
        public static T DeserializeAndUnwrap<T>(string json)
        {
            JObject jo = JObject.Parse(json);
            return jo.Properties().First().Value.ToObject<T>();
        }
    }
    public class Book
    {
        public Publisher[] publishers { get; set; }
        public string pagination { get; set; }
        public Identifiers identifiers { get; set; }
        public Classifications classifications { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string notes { get; set; }
        public int number_of_pages { get; set; }
        public Subject[] subjects { get; set; }
        public string publish_date { get; set; }
        public string key { get; set; }
        public Author[] authors { get; set; }
        public string by_statement { get; set; }
        public Publish_Places[] publish_places { get; set; }
    }
    public class Identifiers
    {
        public string[] lccn { get; set; }
        public string[] openlibrary { get; set; }
        public string[] isbn_10 { get; set; }
        public string[] oclc { get; set; }
        public string[] librarything { get; set; }
        public string[] goodreads { get; set; }
    }
    public class Classifications
    {
        public string[] dewey_decimal_class { get; set; }
    }
    public class Publisher
    {
        public string name { get; set; }
    }
    public class Subject
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    public class Author
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    public class Publish_Places
    {
        public string name { get; set; }
    }
