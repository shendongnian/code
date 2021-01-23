    public class A
    {
        public virtual int Foo() { return 0; }
    }
    public class C : A
    {
        public C()
        {
            // construction takes lot of time    
        }
        private int Bar()
        {
            return 3;
        }
        public override int Foo()
        {
            return Bar() + 1;
        }
    }
    [TestClass] 
    public class Collections
    {
        [TestMethod]
        public void FakingWithIsolatorExample()
        {
            var fakeC = Isolate.Fake.Instance<C>();
            Isolate.WhenCalled(() => fakeC.Foo()).CallOriginal();
            Isolate.NonPublic.WhenCalled(fakeC, "Bar").WillReturn(10);
            int result = fakeC.Foo();
            Assert.AreEqual(11, result);
        }
    }
