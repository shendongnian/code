    namespace MyNamespace.Mocks
    {
        public class MockSomeDbEntities
        {
            public static Mock<SomeDbEntities> Default
            {
                get
                {
                    var mockSomeDbEntities = new Mock<SomeDbEntities>();
                    mockSomeDbEntities
                      .Setup(e => e.SomeMethod(It.IsAny<int>()))
                      .Returns(MockEfResult(Enumerators.SomeCollection).Object);
                    return mockSomeDbEntities;
                }
            }
            private static Mock<TestableEfObjectResult<T>> MockEfResult<T>(Func<IEnumerator<T>> enumerator) where T : class 
            {
                var mock = new Mock<TestableEfObjectResult<T>>();
                mock.Setup(m => m.GetEnumerator()).Returns(enumerator);
                return mock;
            }
        }
    }
    
