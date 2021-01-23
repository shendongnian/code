    public interface IExpenseFilters
    {
        ExpenseFilterType Type { get; set; }
        object Value { get; set; }
    }
    public class ExpenseFilters<T> : IExpenseFilters
    {
        public ExpenseFilterType Type { get; set; }
        public T Value { get; set; }
        object IExpenseFilters.Value
        {
            get { return Value; }
            set
            {
                if (!(value is T))
                    throw new ArgumentException("Incorrect type", "value");
                Value = (T)value;
            }
        }
    }
