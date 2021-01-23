    private class Example : TestMethodClassBase
    {
        protected override void Test(IOrganizationService service)
        {
            service = new OrganizationServiceBuilder(service)
                              .WithSalesOrderNumbersDefaulted()
                              .Build();
            // Execute Function for test
            var id = Example.ValidateAndCreateOrderAndDetail(service);
            Assert.IsNotNull(service.GetEntity<SalesOrder>(id).OrderNumber);
        }
    }
