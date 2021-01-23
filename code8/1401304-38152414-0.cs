    public interface IEntity   
    {
        int UserId { get; set; }
    }
    public Blog : IEntity
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int IserId { get; set; }
    }
