    public interface IObject
    {
        bool isLockedList { get; }
        bool IsLocked { get; }
    }
    
    private void FilterLockedEntities<T>(List<T> list) where T : IObject
    {
        // same code as above should work here...
    }
