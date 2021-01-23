    public class A
    {
        public virtual int m { get; set; }
    }
    [TestFixture]
    public class Tests
    {
        public static void SetProperty(A a)
        {
            a.m = 5;
        }
        [Test]
        public void IsThePropertySet()
        {
            var x = new Mock<A>();
            x.SetupSet<int>(a => a.m = 5).Verifiable();
            SetProperty(x.Object);
            x.Verify();
        }
    }
