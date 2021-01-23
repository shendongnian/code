    public class GeneralLedgerTransactionsMapper : EntityTypeConfiguration<GeneralLedger>
        {
            public GeneralLedgerTransactionsMapper()
            {
                HasMany(s => s._transactions);
            }
        }
