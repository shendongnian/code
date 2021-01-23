    public class OrderRepository<Order> : ICreateable<Order>, IReadable<Order>, IUpdateable<Order>, IDeleteable<Order>
    {
        private ICreateable<Order> _createable;
        private IReadable<Order> _readable;
        private IUpdateable<Order> _updateable;
        private IDeleteable<Order> _deleable;
        public void Add(Order item)
        {
            _createable.Add(item);
        }
        public Order GetById(int id)
        {
            return _readable.GetById(id);
        }
    }
    public class Creatable<T> : ICreateable<T>
    {
        public void Add(T item)
        {
            //Add to entity framework?
        }
    }
    public class Readable<T> : IReadable<T>
    {
        public T GetById(int id)
        {
            //Get from entity framework?
        }
    }
