    public class AmountsMap : EntityTypeConfiguration<Amounts>
    {
         public AmountsMap()
         {
              Ignore(a => a.FinalTotal);
         }
    }
