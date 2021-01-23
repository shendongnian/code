    using System;
    using Akka.Actor;
    using Akka.TestKit.NUnit;
    using NUnit.Framework;
    
    namespace ParentTestExample
    {
        public class ParentGreeter : ReceiveActor
        {
            public ParentGreeter()
            {
                Receive<string>(s => string.Equals(s, "greet parent"), s =>
                {
                    Context.Parent.Tell("Hello parent!");
                });
            }
        }
    
        [TestFixture]
        public class ParentGreeterSpecs : TestKit
        {
            [Test]
            public void Parent_greeter_should_greet_parent()
            {
                Props greeterProps = Props.Create(() => new ParentGreeter());
                // make greeter actor as child of TestActor
                var greeter = ActorOfAsTestActorRef<ParentGreeter>(greeterProps, TestActor);
                greeter.Tell("greet parent");
                // TestActor captured any message that came back
                ExpectMsg("Hello parent!");
            }
        }
    }
