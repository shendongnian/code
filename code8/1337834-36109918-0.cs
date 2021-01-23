    public class MyEntity
        {
            [DisplayName("Debit/Credit")]
            public string Type
            {
                get;
                set;
            }
            [DisplayName("Ledger Name")]
            public string LedgerName
            {
                get;
                set;
            }
            [DisplayName("Debit Amt")]
            public int DebitAmount
            {
                get;
                set;
            }
            [DisplayName("Credit Amt")]
            public int CreditAmount
            {
                get;
                set;
            }
        }
