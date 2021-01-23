    [TestMethod]
    public void TestMethod1() {
        var a = new Availablity() { Id = "111", Status = "A" };
        Mock<IAvailablityRepo> mockRepo = new Mock<IAvailablityRepo>();
        Mock<AvailablityRepoData> RepoData = new Mock<AvailablityRepoData>();
        RepoData.Setup(x => x.GetAvailablity(It.IsAny<Availablity>())).Returns("pass");
        var result = RepoData.Object.GetAvailablity(a);
    }
