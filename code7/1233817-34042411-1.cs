     public class AgreementContext :DbContext
     {
         public AgreementContext() : base("SqlConnection") { }
         public DbSet<Agreement> Agreements { get; set; }
     }
