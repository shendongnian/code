    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("{0} - {1}", Id, Name);
        }
    }
