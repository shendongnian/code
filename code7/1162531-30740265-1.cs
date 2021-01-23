    public class GreeterSpec : TestKit
    {
        private IActorRef greeter;
        public GreeterSpec() : base()
        {
            greeter = Sys.ActorOf<Greeter>("TestGreeter");
        }
        [Fact]
        public void Greeter_should_GreetBack_when_Greeted()
        {
            // set test actor as message sender
            greeter.Tell(new Greet("John Snow"), TestActor);
            // ExpectMsg tracks messages received by TestActors
            ExpectMsg<GreetBack>(msg => msg.Who == "TestGreeter");
        }
        [Fact]
        public void Greeter_should_broadcast_incoming_greetings()
        {
            // create test probe and subscribe it to the event bus
            var subscriber = CreateTestProbe();
            Sys.EventStream.Subscribe(subscriber.Ref, typeof (string));
            greeter.Tell(new Greet("John Snow"), TestActor);
            // check if subscriber received a message
            subscriber.ExpectMsg<string>("John Snow sends greetings");
        }
    }
