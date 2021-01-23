    public FilterControl { }
    public FilterControl<T> : FilterControl { }
    public abstract class ColumnFilter<TCell, TFilterControl> : ColumnFilter
        where TFilterControl : FilterControl, new()
        where TCell : IView, new()
    {
    }
