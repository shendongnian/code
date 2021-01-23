    public partial class Person
    { 
         public int Id { get; set; }
         public string Nome { get;set;}
         public DateTime? DateTime { get; set; }
    }
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
         HasKey(x => x.Id);
         ToTable("dbo.TB_PESSOA");     
    }
