    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var values = new Dictionary<string, object>();
            values.Add("ProductId", 17);
            values.Add("ProductName", "Something");
            values.Add("Price", 29.99M);
            var reader = new FakeDataReader(values);
            var product1 = new Product();
            reader.SetValue(product1, p => p.Id);
            reader.SetValue(product1, p => p.Name);
            reader.SetValue(product1, p => p.Price);
            Assert.AreEqual(17, product1.Id);
            Assert.AreEqual("Something", product1.Name);
            Assert.AreEqual(29.99M, product1.Price);
            var product2 = new Product();
            reader.SetAllValues(product2);
            Assert.AreEqual(17, product2.Id);
            Assert.AreEqual("Something", product2.Name);
            Assert.AreEqual(29.99M, product2.Price);
        }
    }
    public class Product
    {
        [Mapping("ProductId")]
        public int Id { get; set; }
        [Mapping("ProductName")]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class MappingAttribute : Attribute
    {
        public MappingAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
        public string ColumnName { get; private set; }
    }
    public static class IDataReaderExtensions
    {
        public static void SetAllValues(this IDataReader reader, object source)
        {
            foreach (var prop in source.GetType().GetProperties())
            {
                SetValue(reader, source, prop);
            }
        }
        public static void SetValue<T, P>(this IDataReader reader, T source, Expression<Func<T, P>> pe)
        {
            var property = (PropertyInfo)((MemberExpression)pe.Body).Member;
            SetValue(reader, source, property);
        }
        private static void SetValue(IDataReader reader, object source, PropertyInfo property)
        {
            string propertyName = property.Name;
            var columnName = propertyName;
            var mapping = property.GetAttribute<MappingAttribute>();
            if (mapping != null) columnName = mapping.ColumnName;
            var value = reader.GetValue(reader.GetOrdinal(columnName));
            var value2 = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(source, value2, null);
        }
    }
    public static class ICustomFormatProviderExtensions
    {
        public static T GetAttribute<T>(this ICustomAttributeProvider provider)
        {
            return (T)provider.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }
    }
    public class FakeDataReader : IDataReader
    {
        private Dictionary<string, object> values;
        public FakeDataReader(Dictionary<string, object> values)
        {
            this.values = values;
        }
        public int GetOrdinal(string name)
        {
            int i = 0;
            foreach (var key in values.Keys)
            {
                if (key.Equals(name, StringComparison.OrdinalIgnoreCase)) return i;
                i++;
            }
            return -1;
        }
        public object GetValue(int i)
        {
            return values.Values.ToArray()[i];
        }
    }
