    public class Plan
    {
        public int Budget { get; set; }
        public int Expense{ get; set; }
        public int Savings { get; set; }
        public Plan(int budget, int expense, int savings)
        {
            Budget = budget;
            Expense = expense;
            Savings = savings;
        }
        public static Plan operator -(Plan p1, Plan p2)
        {
            return new Plan(p1.Budget - p2.Budget, 
                            p1.Expense - p2.Expense, 
                            p1.Savings - p2.Savings);
        }
    }
