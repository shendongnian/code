    public interface IIndexGettable
    {
        int Index { get; }
    }
    public interface IIndexSettable
    {
        int Index { set; }
    }
     public interface IIndexable : IIndexGettable, IIndexSettable
     {
     }
