        [TestMethod]
        public void TestAllDisposeablesAreDisposed()
        {
            var fooMock = new Mock<IFoo>();
            fooMock.Setup(x=>x.Dispose())
                .Verifiable("Dispose never called on Foo");
            var barMock = new Mock<IBar>();
            barMock.Setup(x => x.Dispose())
                .Verifiable("Dispose never called on Bar");
            using (var myClass = new MyClass(fooMock.Object, barMock.Object))
            {
            }
            fooMock.Verify();
            barMock.Verify();
        }
