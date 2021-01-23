    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo() { Name = "Glenn", Age = 34, Notes = "sample code" };
            Foo bar = new Foo();
            bar.Apply(foo.GetTrackedChanges());
            // ... 
        }
    }
    public class Foo : ChangeTracker
    {
        public Foo()
        {
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; Track("Age", value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; Track("Name", value); }
        }
        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; Track("Notes", value); }
        }
        private string _favoriteColor;
        public string FavoriteColor
        {
            get { return _favoriteColor; }
            set { _favoriteColor = value; Track("FavoriteColor", value); }
        }
    }
    // this abstract class does the work
    public abstract class ChangeTracker : IChangeTrackerResetable
    {
        protected List<Tuple<string, object>> _changes = new List<Tuple<string, object>>();
        public IEnumerable<Tuple<string, object>> GetTrackedChanges()
        {
            return _changes;
        }
        void IChangeTrackerResetable.Reset()
        {
            _changes.Clear();
        }
        protected void Track(string propname, object value)
        {
            _changes.Add(Tuple.Create(propname, value));
        }
        public void Apply(IEnumerable<Tuple<string, object>> changes)
        {
            var inst = this;
            var props = inst.GetType().GetProperties(System.Reflection.BindingFlags.Public);
            foreach(var ch in changes)
            {
                var property = props.FirstOrDefault(r => r.Name == ch.Item1);
                if (property != null)
                {
                    property.SetValue(inst, ch.Item2);
                }
            }
            // reset afterwards
            var o = this as IChangeTrackerResetable;
            o.Reset();
        }
    }
    public interface IChangeTrackerResetable
    {
        void Reset();
    }
