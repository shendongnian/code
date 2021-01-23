      [TestFixture]
        public class IqueryableExtensionsTest
        {
    
            [Test]
            public void QueryableReturnsSqlAndDoesNotThrow()
            {
                using (var dbContext = ObjectContextManager.ScopedOpPlanDataContext)
                {
                    var operations = from operation in dbContext.Operations
                        where operation.Status == (int) OperationStatusDataContract.Postponed
                        && operation.OperatingDate >= new DateTime(2015, 2, 12)
                        select operation;
                    string sql = operations.ShowSql();
                    Assert.IsNotNull(sql);
                }
            }
    
        }
