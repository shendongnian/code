    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Category Parent { get; private set; }
        public Category(int id, string name, Category parent)
        {
            Id = id;
            Name = name;
            Parent = parent;
        }
    }
