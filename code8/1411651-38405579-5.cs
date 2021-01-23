    public async Task Should_Return_Paged_List_Of_Candidate_Objects() {
        //Arrange
        var testList = new List<Candidate>();
        testList.Add(new Candidate() { CandidateId = 1, Name = "Mr", Surname = "Flibble" });
        testList.Add(new Candidate() { CandidateId = 2, Name = "Arnold", Surname = "Rimmer" });
        var totalCount = 0;
        var totalPages = 0;
        var mockManager = new Mock<ICandidateManager>();
        mockManager.Setup(x => x.GetCandidates(out totalCount, out totalPages, It.IsAny<int>(), It.IsAny<int>())).Returns(testList);
        var controller = new CandidateManagerController(mockManager.Object);
        SetupControllerForTests(controller);
        //Act
        var response = await controller.Get(1, 1).ExecuteAsync(System.Threading.CancellationToken.None);
        //Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
        Assert.IsTrue(response.Headers.Contains("X-Pagination"));
    }
