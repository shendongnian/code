    private class Example : TestMethodClassBase
    {
        // Ids struct is used by the TestMethodClassBase to clean up any entities defined
        private struct Ids
        {
            public static readonly Id<SalesOrder> SalesOrder = new Id<SalesOrder>("7CF2BB0D-85D4-4B8C-A7B6-371D3C6EA37C");
        }
        protected override void InitializeTestData(IOrganizationService service)
        {
            service = new OrganizationServiceBuilder(service).WithSalesOrderNumbersDefaulted().Build();
            service.Create(new SalesOrder());
        }
        protected override void Test(IOrganizationService service)
        {
            // Run test
            Assert.IsNotNull(service.GetFirst<SalesOrder>().OrderNumber);
        }
    }
