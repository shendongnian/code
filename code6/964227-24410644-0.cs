    public abstract class ColumnFilter<TCell, TFilterControl, TFilter> : ColumnFilter
        where TFilterControl : FilterControl<TFilter>, new()
        where TCell : IView, new()
    {
    }
