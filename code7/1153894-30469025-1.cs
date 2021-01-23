    [Test]
    public void TestModelMessagesAreUpdatedFromJobRunner() {
        var mockImporter = new Mock<IImporter>();
        List<Message> expectedMessages = new List<Message>();
        mockImporter.Setup(x=>x.RunJob(It.IsAny<Jobs>(), out expectedMessages));
        var model = new ImportsAndLoadsViewModel();
        // Inject the mocked importer while constructing your controller
        var sut = new ImportController(mockImporter.Object);
        
        // call the action you're testing on your controller
        ViewResult response = (ViewResult)sut.ImportsAndLoads(model);
        // Validate the the model has been updated to have the messages
        // returned by the mocked importer.
        Assert.AreEqual(expectedMessages, 
                        ((ImportsAndLoadsViewModel)response.Model).lstMessages);
    }
