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
                   Income = ...,
                   Expense = ...,                                                              
               };
    var accumulated = sums.Accumulate((previous, next) => new MonthlyIncomeAndExpenses
    {
        Month = next.Month,
        Income = previous.Income + next.Income,
        Expense = previous.Expense + next.Expense,
    });
