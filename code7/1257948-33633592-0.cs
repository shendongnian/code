    var repo= new Mock<IRepository>();
    var dummyCustomer = new Customer { Name ="Test"}
    repo.Setup(s=>s.GetCustomer(It.IsAny<int>).Returns();
    
    var customerMgr = new CustomerManager(repo.Object);
    var actualResult = customerMgr.GetCustomer(345);
    //Assert something now.
