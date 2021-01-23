    public class ZipActor : ReceiveActor
    {
        public ZipActor()
        {
            Receive<ZipMessage>(message => HandleZipMessage(message));
        }
        private void HandleZipMessage(ZipMessage message)
        {
            Console.WriteLine(string.Format("Received: {0} for {1}", typeof(ZipMessage).Name, message.SourceFolderPath));
            // TODO: Zip operations
            Context.Parent.Tell(new IncrementFolderCountMessage());
        }
    }
    public class ZipMessage
    {
        public readonly string SourceFolderPath;
        public ZipMessage(string sourceFolderPath)
        {
            SourceFolderPath = sourceFolderPath;
        }
    }
	
    [TestFixture]
    public class ZipActorTests : TestKit
    {
        [Test]
        public void ZipActor_WhenReceivedZip_ShouldIncrementFolderCount()
        {
            // Arrange
            // (make ZipActor child of TestActor)
            var props = Props.Create(() => new ZipActor());
            var actor = ActorOfAsTestActorRef<ZipActor>(props, TestActor);
            string path = "some path";
            
            // Act
            actor.Tell(new ZipMessage(path));
            // Assert
            ExpectMsg<IncrementFolderCountMessage>();
        }
    }
