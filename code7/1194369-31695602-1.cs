    public class Expense {
        public decimal ExpenseValue { get; private set; }
        public int NumberOfItems { get; private set; }
        public decimal Result { get; private set; }
               
        public decimal Calculate(decimal expenseValue, int numberOfItems) {
            ExpenseValue = expenseValue;
            NumberOfItems = numberOfItems;
            Result = ExpenseValue * NumberOfItems;
            return Result;
        }
        public Expense() {
            Calculate(0, 0);
        }
    }
