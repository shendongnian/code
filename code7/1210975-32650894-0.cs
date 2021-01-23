    using (Microsoft.QualityTools.Testing.Fakes.ShimsContext.Create())
    {
         // Setup Shim function for PatIndex:
         System.Data.Entity.SqlServer.FakesShimSqlFunctions.PatIndexStringString = (pattern, target) => 
         {
            // Implement PatIndex function here
            throw new NotImplementedException();
         }
         // Your Unit test code goes here
    }
