        [TestMethod]
        public void Test01()
        {
            using (ShimsContext.Create())
            {
                var dbConnectionOpened = false;
                var fakeConnection = new StubDbConnection()
                {
                    Open01 = () => { dbConnectionOpened = true; }
                };
                var fakeCommand = new StubDbCommand()
                {
                    ExecuteDbDataReaderCommandBehavior = (com) => GetFakeReader()
                };
                var fakeDbProviderFactory = new StubDbProviderFactory()
                {
                    CreateConnection01 = () => fakeConnection,
                    CreateCommand01 = () => fakeCommand
                };
                ShimDbProviderFactories.GetFactoryString = (arg1) => fakeDbProviderFactory;
                var val = SqlConnectionFactory.TableDoesNotExist("testTable", "conn");
                Assert.IsTrue(dbConnectionOpened);
                Assert.IsTrue(val);
            }            
        }
        private DbDataReader GetFakeReader()
        {
            const int count = 0;
            var dt = new DataTable("Test-Table");
            dt.Columns.Add(new DataColumn("Count"));
            dt.Rows.Add(count);
            return dt.CreateDataReader();
        }
