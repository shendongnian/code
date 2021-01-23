    public interface IRow<TRowHeader, TCell>
    {
        TRowHeader RowHeader { get; }
        IList<TCell> Zellen { get; }
    }
