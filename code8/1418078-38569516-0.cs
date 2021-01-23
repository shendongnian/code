	public static void Main()
	{
		var budgets = new List<Budget>()
		{
			new Budget(){ Id = 1, Range = "A" },
			new Budget(){ Id = 2, Range = "B" },
			new Budget(){ Id = 3, Range = "C" },
			new Budget(){ Id = 4, Range = "C" },
			new Budget(){ Id = 5, Range = "A" }
		};
		
		var duplicateBudgetGroups = budgets.GroupBy(budget => budget.Range).Where(group => group.Count() > 1);
		
		foreach (var duplicateBudgets in duplicateBudgetGroups)
		{
			Console.WriteLine("Duplicate Range {0}", duplicateBudgets.Key);
			foreach (var budget in duplicateBudgets)
			{
				Console.WriteLine("Budget {{ Id = {0}, Range = {1} }}", budget.Id.ToString(), budget.Range);
			}
		}
	}
	
	class Budget {
		public int Id { get; set; }
		public string Range { get; set; }
	}
