    public class MyClass
    {
        public List<Object> MyList { get; set; }
        public MyClass myField;
        public MyClass()
        {
            this.MyList = new List<object>();
        }
        public void ClearLists()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType.FullName == typeof(List<Object>).FullName)
                {
                    (prop.GetValue(this) as List<Object>).Clear();
                }
            }
        }
        public void FieldAction(Type fieldType, string methodName, params object[] parameters)
        {
            foreach (var field in this.GetType().GetFields())
            {
                if (field.FieldType.Equals(fieldType))
                {
                    var val = field.GetValue(this);
                    val.GetType().GetMethod(methodName).Invoke(val, parameters);
                }
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            var c = new MyClass();
            c.MyList.Add(new Object());
            c.ClearLists();
            Console.WriteLine(c.MyList.Count.ToString()); // 0
            c.myField = new MyClass();
            c.myField.MyList.Add(new Object());
            c.FieldAction(typeof(MyClass), "ClearLists");
            Console.WriteLine(c.myField.MyList.Count.ToString()); // 0
        }
    }
