        [TestMethod()]
        [DeploymentItem("MyTestProject\\testdatasource.accdb")]
        [DataSource("MyJetDataSource")]
        public void MyTestMethod()
        {
            int a = Int32.Parse(context.DataRow["Arg1"].ToString());
            int b = Int32.Parse(context.DataRow["Arg2"].ToString());
            Assert.AreNotEqual(a, b, "A value was equal.");
        }
