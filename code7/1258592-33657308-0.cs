    public class Person {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [CreatedAt] public DateTime CreatedAt;
    }
