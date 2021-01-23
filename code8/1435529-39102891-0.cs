    [Test]
        public void TheTest()
        {           
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\results\test.csv", true))
    {
    
            try
            {
                Assert.AreEqual("text", "text");
                file.WriteLine("{0},{1},{2}", "time", "test", "PASS");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                file.WriteLine("{0},{1},{2}", "time", "test", "FAIL");
            }
    
            //do next step
    
            }
        }
