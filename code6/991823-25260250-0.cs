    [Route("/Calculate","GET")]
	public class DefaultCalculator : ILoanCalculator
	{
		public decimal Amount { get; set; }
		public decimal TermYears { get; set; }
		public int TermMonths { get; set; }
		public decimal IntrestRatePerYear { get; set; }
		public DateTime StartDate { get; set; }
		public decimal MonthlyPayments { get; set; }
		public void Calculate()
		{
			throw new NotImplementedException();
		}
	}
