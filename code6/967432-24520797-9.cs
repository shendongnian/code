        public abstract class BaseClass
        {
            public string Name
            {
                get { return GetName(); }
                set { SetName(value); }
            }
            public abstract string GetName();
            public abstract void SetName(string value);
        }
        [Test]
        public void TestNameGetter()
        {
            var mock = Substitute.For<BaseClass>();
            mock.GetName().Returns("ABC");
            string name = mock.Name;
            Assert.AreEqual("ABC", name, "Wrong name");
            mock.DidNotReceive().SetName(Arg.Any<string>());
            mock.Received().GetName();
        }
