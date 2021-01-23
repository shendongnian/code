    public class ModelsGetSetTest
    {
        [ClassData(typeof(ModelTestDataGenerator))]
        [Theory]
        public void GettersGetWithoutError<T>(T model)
            where T: BaseEntity
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < properties.Length; i++)
            {
                var prop = properties[i];
                prop.GetValue(model);
            }
        }
        [ClassData(typeof(ModelTestDataGenerator))]
        [Theory]
        public void SettersSetWithoutError<T>(T model)
            where T : BaseEntity
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < properties.Length; i++)
            {
                var prop = properties[i];
                prop.SetValue(model, null);
            }
        }
        public class ModelTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { new UserRole() },
                new object[] { new User() },
                new object[] { new Role() }
            };
            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
