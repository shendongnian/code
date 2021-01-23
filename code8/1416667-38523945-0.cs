    public class DataField
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class MyDynamicCollection : DynamicObject
    {
        private Collection<DataField> _list;
        public MyDynamicCollection(Collection<DataField> list)
        {
            _list = list;
        }
        public Object this[string name]
        {
            get
            {
                return _list.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.Value;
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return result != null;
        }
    }
    public class CustomList : ObservableCollection<DataField>
    {
        private MyDynamicCollection _innerCollection;
        public CustomList()
        {
            _innerCollection = new MyDynamicCollection(this);
        }
        public DynamicObject AsDynamic()
        {
            return _innerCollection;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CustomList c = new CustomList();
            dynamic d = c.AsDynamic();
            object a;
            try
            {
                a = d.Invoke;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var newDataField = new DataField() { Name = "Invoke", Value = 1000 };
            c.Add(newDataField);
            a = d.Invoke;
            c.Remove(newDataField);
            try
            {
                a = d.SomeProperty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(a);
        }
    }
