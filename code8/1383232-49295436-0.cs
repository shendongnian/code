    [TestClass]
    public class OutProtectedMockFixture
    {
        delegate void DoSomethingCallback(out string str);
        [TestMethod]
        public void test()
        {
            // Arrange
            string str;
            var classUnderTest = new Mock<SomeClass>();
            classUnderTest.Protected().Setup<bool>("DoSomething", ItExpr.Ref<string>.IsAny)
                .Callback(new DoSomethingCallback((out string stri) =>
                    {
                        stri = "test";
                    })).Returns(true);
            // Act
            var res = classUnderTest.Object.foo(out str);
            // Assert
            Assert.AreEqual("test", str);
            Assert.IsTrue(res);
        }
    }
    public class SomeClass
    {
        public bool foo(out string str)
        {
            return DoSomething(out str);
        }
        protected virtual bool DoSomething(out string str)
        {
            str = "boo";
            return false;
        }
    }
