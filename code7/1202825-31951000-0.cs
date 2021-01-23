    public class Entity1
        {
            public decimal SodaId { get; set; }
            [ForeignKey("Entity2")]
            public int Id { get; set; }
            public virtual Entity2 Entity2 { get; set; }
        }
    public class Entity2
        {
            public int Id { get; set; }
            public string PopId { get; set; }
            public virtual ICollection<Entity1> Entity1 { get; set; }
        }
