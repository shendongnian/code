    static int NumberTest = 3;
        [TestMethod]
        public void GlobalTest()
        {
            try
            {
                // Your failed code
                Assert.Fail(); // to remove of course
            }
            finally
            {
                NumberTest--;
                if (NumberTest > 0)
                    GlobalTest();
            }
        }
