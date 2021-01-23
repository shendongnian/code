    public class ListOfArray<T> : List<T[]>
    {
        public new void Add(params T[] args)
        {
            base.Add(args);
        }
    }
