    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
    public class GenreMap : ClassMap<Genre>
    {
        public GenreMap()
        {
            Id(x => x.GenreId).Column("Id");
            Map(x => x.Name);
            Map(x => x.Description);
            Table("Genres");
        }
    }
