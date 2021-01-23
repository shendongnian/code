    public interface IObjectsCollection<T> where T : SObject
    {
        List<T> Items{ get; }
        void Add(T item);
    }
    public class BeamsCollection : IObjectsCollection<Beam>
    {
        public List<Beam> Items { get; private set; }
    
        public BeamsCollection ()
        {
            Items = new List<Beam>();
        }
    
        public void Add(Beam item)
        {
            Items.Add(beam);
        }
    }
    public class ColumnsCollection : IObjectsCollection<Column>
    {
        public List<Column> Items { get; private set; }
    
        public ColumnsCollection ()
        {
            Items = new List<Column>();
        }
    
        public void Add(Column item)
        {
            Items.Add(column);
        }
    }
