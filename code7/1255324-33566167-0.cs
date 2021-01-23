    public interface IBar {
    }
    public class Foo 
    {
       public Foo(IBar bar)
       {
           //...
       }
       public virtual int GetValue(){ return 0;}
       public virtual void DoActual()
       {
           var value = GetValue();
       }
    }
    [TestFixture]
    public class SomeTests {
        [Test]
        public void TestMethodCalled() {
            var barMock = new Mock<IBar>();
            var mock = new Mock<Foo>(barMock.Object) { CallBase = true };
            mock.Setup(x => x.GetValue()).Returns(1);
            mock.Object.DoActual();
            //asserts
            mock.Verify(x => x.GetValue());
        }
    }
