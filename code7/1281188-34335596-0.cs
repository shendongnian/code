    public interface IMyList<T>: IList<T> where T : IMyListItem
    {
        // Stuff
    }
    public class MyList : List<MyListItem>, IMyList<MyListItem>
    {
    }
