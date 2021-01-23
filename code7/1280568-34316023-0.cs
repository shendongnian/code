    public interface ICell<TContent>
    {
        TContent Content { get; }
        string Background { get; }
        string Foreground { get; }
    }
    public interface IRow<TRowHeader,TCell>
    {
        TRowHeader RowHeader { get; }
        IList<TCell> Zellen {get;}
    }
