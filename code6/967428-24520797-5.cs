        public abstract class BaseClass
        {
            public virtual string Name { get; set; }
        }
        [Test]
        public void TestNameGetter()
        {
            var mock = Substitute.For<BaseClass>();
            mock.Name.Returns("ABC");
            string name = mock.Name;
            Assert.AreEqual("ABC", name, "Wrong name");
        }
