    public interface IAddOnlyCollection<T> : IReadOnlyCollection<T> // could be IReadOnlyList<T> if you wish
    {
        void Add(T item);
    }
    public class AddOnlyCollection<T> :
        System.Collections.ObjectModel.Collection<T>, IAddOnlyCollection<T>
    {
        // Same as above
    }
