    public  class CodeConfiguration : EntityTypeConfiguration<Code>
    {
        public CodeConfiguration()
        {
            HasKey(h => h.Id);
            HasOptional(x => x.HelperCode).WithRequired(x => x.Code);
        }
    }
