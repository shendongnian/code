    public class Company
    {
        public Company ()
        {
            Id = null;
            TipoCompanyString = ((int)Enums.EnumType.TipoCompany.Matriz).ToString();
            TipoCompany = Enums.EnumType.TipoCompany.Matriz;
            Name = string.Empty;
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string TipoCompanyString { get; set; }
        public Enums.EnumType.TipoCompany TipoCompany { 
            get {
                var intValue = Convert.ToInt32(TipoCompanyString);
                return (Enums.EnumType.TipoCompany)intValue;
            }
            set {
                TipoCompanyString = ((int)value).ToString()
            }
        }
    }
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            ToTable("COMPANY");
            HasKey(t => new { t.Id});
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("EMP_ID");
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(35)
                .HasColumnType("Varchar")
                .HasColumnName("EMP_NM");
            Property(t => t.TipoCompanyString)
                .IsRequired()
                .HasColumnType("Varchar")
                .HasColumnName("EMP_TYPE");
        }
    }
    public class EnumTypeCompany
    {
        public enum TypeCompany
        {
            [Description("Matriz")]
            Matriz = 01,
            [Description("Filial")]
            Filial = 02,
        }
    }
