    [TestMethod]
    public void TestCustomerById()
    {
        using (var ctx = new AWLT.AWLT())
        {
            var customer = ctx.GetCustomerById(1).ToList();
            // Assert.AreNotEqual(0, customer.Count());
            Assert.AreNotEqual(0,
                ((IObjectContextAdapter)ctx).ObjectContext
                .ObjectStateManager
                .GetObjectStateEntries(System.Data.Entity.EntityState.Unchanged).Count());
        }
    }
