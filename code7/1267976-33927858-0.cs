    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Name { get; set; }
        public int UsuCad { get; set; }        
        public int UsuAlt { get; set; }
        public virtual SomeSecondClass SomeSecondClass { get; set; }
        public virtual SomeThirdClass SomeThirdClass { get; set; }
    }
