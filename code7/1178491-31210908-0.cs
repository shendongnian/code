    public class ModulosPorUsuario
    {
        // added this constructor
        public ModulosPorUsuario()
        {
            this.Modules = new List<Module>();
        }        
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Module> Modules{ get; set; }
    }
