        public class MockClass : BaseClass
        {
            public bool GetNameWasCalled = false;
            public bool SetNameWasCalled = false;
            protected override string GetName() { GetNameWasCalled = true; return "ABC"; }
            protected override void SetName(string value) { SetNameWasCalled = true; }
        }
        [Test]
        public void TestNameGetter()
        {
            // arrange
            var mock = new MockClass();
            // act
            string name = mock.Name;
            // assert
            Assert.AreEqual("ABC", name, "Wrong name");
            Assert.False(mock.SetNameWasCalled);
            Assert.True(mock.GetNameWasCalled);
        }
