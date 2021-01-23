    internal class MonthlyIncomeAndExpenses
    {
        public DateTime Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
    }
    var sums = from month in monthsToDate
               select new MonthlyIncomeAndExpenses
               {
                   Month = month,
                   Income = ...,   // what you already have
                   Expense = ...,  // what you already have                                                            
               };
