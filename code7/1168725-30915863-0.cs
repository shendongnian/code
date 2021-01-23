    public class SomeTests {
        Mock<ISession> _sessionMock;
        Mock<IClientContext> _clientContextMock;
        [Setup]
        public void Setup() {
            _sessionMock = new Mock<ISession>();
            _clientContextMock = new Mock <IClientContext();
        }
        MovieController CreateSut() {
            return new MovieController(_sessionMock.Object, _clientContextMock.Object, ...);
        }
        [Test]
        public void TestSomething() {
            _sessionMock.Setup(x=>...);
            
            //...
            var sut = CreateSut();
           //...
        }
    }  
