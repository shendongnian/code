    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public int UsuCad { get; set; }        
        public int UsuAlt { get; set; }
    
        [ForeignKey("UsuCad")]
        [InverseProperty("UsuarioID")]
        public virtual Usuario UsuarioCad { get; set; }
        [ForeignKey("UsuAlt")]
        [InverseProperty("UsuarioID")]
        public virtual Usuario UsuarioAlt { get; set; }
    }
