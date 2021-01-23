    [TestMethod]
    public async Task TestMethod1()
    {
        var fakeCustomerRepo = new Mock<ICustomerRepository>();
        var foo = false;
        fakeCustomerRepo.Setup(repository => repository.AnyAsync(It.IsAny<Expression<Func<CustomerEntity, bool>>>()))
            .Callback<Expression<Func<CustomerEntity, bool>>>(
                expression =>
                {
                    var func = expression.Compile();
                    foo = func(new CustomerEntity() {Email = "foo@gmail.com"});
                })
            .Returns(() => Task.FromResult(foo));
        var customer = new CustomerEntity() {Email = "foo@gmail.com"};
        var result = await fakeCustomerRepo.Object.AnyAsync<CustomerEntity>(c => c.Email == customer.Email);
        Assert.IsTrue(result);
        customer = new CustomerEntity() { Email = "boo@gmail.com" };
        result = await fakeCustomerRepo.Object.AnyAsync<CustomerEntity>(c => c.Email == customer.Email);
        Assert.IsFalse(result);
    }
