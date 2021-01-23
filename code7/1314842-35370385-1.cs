    public class Test
    {
        [Fact]
        public void Get_all_fields()
        {
            var fields = typeof(TestDerived).GetTypeInfo().GetAllFields();
            Assert.True(fields.Any(f => f.Name == "FooField"));
            Assert.True(fields.Any(f => f.Name == "BarField"));
        }
        [Fact]
        public void Get_all_properties()
        {
            var properties = typeof(TestDerived).GetTypeInfo().GetAllProperties();
            Assert.True(properties.Any(p => p.Name == "FooProp"));
            Assert.True(properties.Any(p => p.Name == "BarProp"));
        }
    }
    public class TestBase
    {
        public string FooField;
        public int FooProp { get; set; }
    }
    public class TestDerived : TestBase
    {
        public string BarField;
        public int BarProp { get; set; }
    }
