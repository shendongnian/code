    [TestClass]
    public class C
    {
        [TestMethod]
        public void M()
        {
            Mapper.CreateMap<SomeObject, SomeOtherObject>();
            SomeObject source = GetSource();
            SomeOtherObject target = GetTarget();
            Mapper.Map(source, target);
            Assert.AreEqual(123, target.Id);
            Assert.AreEqual("An Object", target.Name);
        }
        private static SomeOtherObject GetTarget()
        {
            return new SomeOtherObject {Id = 123};
        }
        private static SomeObject GetSource()
        {
            return new SomeObject {Name = "An Object"};
        }
        private class SomeOtherObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        private class SomeObject
        {
            public string Name { get; set; }
        }
    }
