    public class ToBeTested
    {
        private readonly IEventAggregator _eventAggregator;
        public ToBeTested( IEventAggregator eventAggregator )
        {
            _eventAggregator = eventAggregator;
        }
        public void DoStuff()
        {
            _eventAggregator.GetEvent<OneEvent>().Publish( "test" );
        }
    }
    public class OneEvent : PubSubEvent<string>
    {
    }
    [TestFixture]
    internal class Test
    {
        [Test]
        public void DoStuffTest()
        {
            var myEvent = new MyOneEvent();
            var myEventAggregator = Substitute.For<IEventAggregator>();
            myEventAggregator.GetEvent<OneEvent>().Returns( myEvent );
            var toBeTested = new ToBeTested( myEventAggregator );
            toBeTested.DoStuff();
            Assert.That( myEvent.ReceivedPayload, Is.EqualTo( "test" ) );
        }
        private class MyOneEvent : OneEvent
        {
            public override void Publish( string payload )
            {
                ReceivedPayload = payload;
            }
            public string ReceivedPayload
            {
                get;
                private set;
            }
        }
    }
