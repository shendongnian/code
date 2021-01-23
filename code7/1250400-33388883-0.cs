    public class TypeB { }
    public class TypeA
    {
        public TypeB MyProperty1 { get; set; }
        public TypeA()
        {
            MyProperty1 = new TypeB();
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<object> objects = new List<object>();
            objects.Add("alma");
            objects.Add(new TypeA());
            objects.OfType<TypeA>().Single().MyProperty1.Should().BeOfType<TypeB>();
        }
    }
