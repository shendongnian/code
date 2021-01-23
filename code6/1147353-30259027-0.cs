    using System;
    
    namespace AccountSummary
    {
        class masterTransData
        {
            public long TransNo { get; set; }
            public DateTime TransDate { get; set; }
            public long AccountNo { get; set; }
            public decimal Amount { get; set; }
            public decimal getBalance()
            {
                decimal balance = 0M;
                masterTransData[] mtd = transData();
                for(int i=0; i<mtd.length; i++)
                {
                    balance += mtd[i].amount; 
                }
                return balance;
            }
        }
    }
