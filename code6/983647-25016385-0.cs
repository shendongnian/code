    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Food> Foods { get; set; }
        public ICollection<Book> Books { get; set; }
    }
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Food : Item
    {
        public int CookedById { get; set; }
        [ForeignKey("CookedById")]
        public Person CookedBy { get; set; }
    }
    public class Book : Item
    {
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Person Author { get; set; }
    }
