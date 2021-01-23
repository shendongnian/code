    [TestMethod]
    public void SaveShouldWork()
    {
      var moqRepo = new Mock<IRepository>();
      moqRepo.Setup(s=>s.Save(It.IsAny<Client>)).Verifiable();
      var cs = new ClientService(moqRepo.Object); 
      var client = new Client { Name = "S" };
      cs.Save(client);
      //Test passed :)
    }
