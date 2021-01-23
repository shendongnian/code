    public class CategoryEntries : List<CategoryEntry>
    {
        public decimal TotalExpense()
        {
            return this.Select(category => category.ExpenseAmount).Sum();
        }
        public decimal PercentOfTotal(CategoryEntry entry)
        {
            return entry.TotalExpense/TotalExpense();
        }
    }
