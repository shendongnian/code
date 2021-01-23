    public class Post
    {
        protected Post() // this constructor is only for EF proxy creation
        {
        }
        public Post(string name, string description)
        {
            if (/* validation check, inline or delegate */)
                throw new ArgumentException();
            Name = name;
            Description = description;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
