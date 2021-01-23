     var inputTestDataAsNonFilteredCustomers = new List<Customer> {cust1, cust2};
     var customersRepoMock = new Mock<IBaseRepository<Customer>>();
    
                    IQueryable<Customer> filteredResult = null;
                    customersRepoMock.Setup(x => x.Where(It.IsAny<Expression<Func<Customer, bool>>>()))
                        .Callback((Expression<Func<Customer, bool>>[] expressions) =>
                        {
                            if (expressions == null || expressions.Any() == false)
                            {
                                return;
                            }
                            Func<Customer, bool> wereLambdaExpression = expressions.First().Compile();  //  x=>x.isActive is here
                            filteredResult = inputTestDataAsNonFilteredCustomers.Where(wereLambdaExpression).ToList().AsQueryable();// x=>x.isActive was applied
                        })
                       .Returns(() => filteredResult.AsQueryable());
