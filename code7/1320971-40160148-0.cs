        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HoofNotesUtilitiesCreateDirectoryTest()
        {
            try
            {
                // Test whether it throws an exception
                // It'd better, * is not a valid directory name
                // when you are creating one
                HoofNotesUtilities.CreateDirectory("*");
            }
            catch (System.ArgumentException e)
            {
                if (e.Message == "Illegal characters in path.")
                {
                    // You got the exception that you expected - GREAT
                    // Do whatever you need to do with it here. 
                    // THEN rethrow it, because the test expects it.
                    // If you don't, the test will fail and stop. 
                    throw;
                }
                else
                {
                    // Wrong exception, fail the test
                    Debug.Assert(false);
                }
            }
        }
