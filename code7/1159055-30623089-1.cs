        [DataSource("Table:CSharpDataDrivenTests.xml#FirstTable")]
        [Test]
        static public void NUnitWriter()
        {
            int x = 0
            int errorCode = Convert.ToInt32(TestContext.DataRow["ErrorCode"]);
            Assert.AreEqual (x, errorCode);
        }
  
