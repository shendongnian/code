    public interface IRow<TRowHeader, TCell> where TCell : ICell
    {
        TRowHeader RowHeader { get; }
        IList<TCell> Zellen { get; }
    }
