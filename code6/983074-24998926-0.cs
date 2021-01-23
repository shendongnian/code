    [Table("procedures", Schema = "sys")]
    public class Procedure
    {
        [Column(Order = 0)]
        public string name { get; set; }
        [Key]
        [Column(Order = 1)]
        public int object_id { get; set; }
    }
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public virtual DbSet<Procedure> Procedures { get; set; }
    }
    using (var context = new Model1())
    {
        foreach (var p in context.Procedures)
        {
            Console.WriteLine("{0}: {1}", p.object_id, p.name);
        }
    }
