    [TestMethod]
    MyTestWithInternSqlConnection()
    {
       using (ShimsContext.Create())
       {
          // simulate a connection
          ShimSqlConnection.AllInstances.Open = connection => { };
          string commandText;
          
          // shim-Mock all called methods
          ShimSqlCommand.AllInstances.ExecuteReader = command =>
          {
             commandText = command.CommandText;
             return new ShimSqlDataReader();
          };
          int readCount = 0;
          ShimSqlDataReader.AllInstances.Read = reader => readCount == 0;
          ShimSqlDataReader.AllInstances.GetSqlStringInt32 = (reader, i) =>
          {
             readCount++;
             return "testServer";
          };
          var theReadedString = AMethodUnderTestThatReadsFromDatabaseAString();
          Assert.IsTrue(theReadedString == "testServer");
       }
    }
