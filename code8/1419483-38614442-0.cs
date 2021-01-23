        public decimal CalculatePayment()
        {
            DateTime lastPaymentDueDate = new DateTime(2016, 7, 27);
            DateTime thisPaymentDate = new DateTime(2016, 10, 27);
            decimal policy = 10000.0M;
            decimal mthFee = 5000.0M;
            decimal mthFine = policy * 2.0M / 100.0M;
            decimal payAmount = 0.0M;
            DateTime nextPaymentDueDate = lastPaymentDueDate.AddMonths(1);
            int thisPayJulian = (int)thisPaymentDate.ToOADate();
            int nextDueJulian = (int)nextPaymentDueDate.ToOADate();
            if (thisPayJulian < nextDueJulian)
            {
                //nothing to pay
                return payAmount;
            }
            while (thisPayJulian - nextDueJulian > 15)
            {
                //deal with late payments
                payAmount += mthFine + mthFee;
                nextPaymentDueDate = nextPaymentDueDate.AddMonths(1);
                nextDueJulian = (int)nextPaymentDueDate.ToOADate();
            }
            if (thisPayJulian >= nextDueJulian)
            {
                //deal with regular payments
                payAmount += mthFee;
            }
            return payAmount;
        }
