     public class PerfilContext : DbContext
     { 
          public PerfilContext()
             :base("PerfilContexto")
          {
          }
          public DbSet<Perfil>  Dados { get; set; } 
     }
