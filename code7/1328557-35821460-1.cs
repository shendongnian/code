    public interface IDatabaseItem
    {
         int? Id { get; }
         SetID(int value);
    }
    public class DBEntity : IDatabaseItem
    {
        public int? Id { get; private set; }
        public void SetID(int value)
        {
            if (Id == null)
            {
                Id = value;
            }
            else
            {
                throw new Exception("Cannot set assigned Id; can only set Id when it is not assgined.");
            }
        }
    }
    public class Table<T> where T : IDatabaseItem
    {
        static int _id = 0;
        private readonly List<T> _set = new List<T>();
        public IEnumerable<T> Set() { return _set; }
        public void Insert(T item)
        {
            if (item.Id == null)
            {
                _id++;
                item.SetID(_id);
                _set.Add(item);
            }
            else
            {
                //Handle this case. Something else set the ID, yet you're trying to insert it. This would, with your code, imply a bug.
            }
        }
    }
