    public interface ICell 
    { 
        string Background { get; }
        string Foreground { get; }
    }
    public interface ICell<TContent> : ICell
    {
        TContent Content { get; }
    }
