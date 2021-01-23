    public class AmountsMap : EntityTypeConfiguration<Amounts>
    {
         public SaleMap()
         {
              Ignore(s => s.FinalTotal);
         }
    }
