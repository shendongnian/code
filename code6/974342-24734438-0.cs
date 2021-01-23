    modelBuilder.Configurations.Add(new FormulaConfig());
    public class FormulaConfig : EntityTypeConfiguration<Formula>
    {
        public FormulaConfig()
        {               // one-to-many
            this.HasRequired(x => x.Article)
                .WithOptional(x=>x.Formula)         
                .WillCascadeOnDelete();
        }
    }
