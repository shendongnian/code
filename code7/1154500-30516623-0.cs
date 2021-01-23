    public class Principal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Dependent Dependent { get; set; }
    }
    public class Dependent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Principal Principal { get; set; }
    }
