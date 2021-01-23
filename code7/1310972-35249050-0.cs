    using System;
    namespace demo
    {
        class Class1
        {
            public decimal Subtotal { get; set; } //= 5;
            public decimal SalesTax
            {
                get
                {
                    decimal rateGST = Decimal.Parse(Properties.Settings.Default.rateGST);
                    decimal ratePST = Decimal.Parse(Properties.Settings.Default.ratePST);
                    decimal result = Subtotal * (rateGST + ratePST);
                    return result;
                }
            }
        }
    }
