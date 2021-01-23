    [TestFixture]
    public class SomeClassTests
    {
        [Fake] public IFakeable Fake {get;set;}
        [UnderTest] public SomeClass Subject {get;set;}
        [SetUp]
        public void Setup()
        {
            Fake.InitializeFixture(this);
        }
        [Test]
        public void FakeCall_CallsIFakeabl_FakeYou()
        {
            Subject.FakeCall();
    
            A.CallTo(() => Fake.FakeYou()).MustHaveHappened();
        }
    }
