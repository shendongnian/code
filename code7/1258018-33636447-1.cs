    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void ValidateShouldThrowException()
    {
      var moqRepo = new Mock<IRepository>();
      var cs = new ClientService(moqRepo.Object); 
      var client = new Client { Name = "S" };
    
      cs.Save(client);
    }
