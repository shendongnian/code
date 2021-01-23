    [TestClass]
    public class C
    {
        [TestMethod]
        public void M()
        {
            Mapper.CreateMap<SomeObject, SomeOtherObject>();
            SomeObject source =  new SomeObject {Name = "An Object"};
            SomeOtherObject target = new SomeOtherObject {Id = 123};
            Mapper.Map(source, target);
            Assert.AreEqual(123, target.Id);
            Assert.AreEqual("An Object", target.Name);
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
