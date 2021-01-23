    [TestFixture]
        public class FileReaderTests
        {
            [Test]
            public void ShouldDisplayANiceMessage_WhenFileIsInaccessible()
            {
                var moq = new Moq.Mock<IFileReader>();
                moq
                    .Setup( x => x.ReadFile( Moq.It.IsAny<string>() ) )
                    .Throws<Exception>();
    
                var metaDataReader = new MetaDataReader( moq.Object );
                metaDataReader.ReadVideoFile( "video.mp4" );
                Assert.AreEqual( 1, meaDataReader.Errors.Count );    
            }
        }
