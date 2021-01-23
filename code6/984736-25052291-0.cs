    public class ApplicationUser : IdentityUser
    {
        public String Pais { get; set; }
        public String Email { get; set; }
        public DateTime UltimoLogin { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String Tipo { get; set; }
        public Boolean Activado { get; set; }
    }
