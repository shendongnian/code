    public class BaseDBTest
    {     
        private Fixture _fixture = new Fixture();
        public BaseDBTest()
        { }
        public Ploeh.AutoFixture.Fixture fixture { get { return _fixture; } }
    }
