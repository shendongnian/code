    protected static void ThrowsException<T>(Action action) where T : Exception
        {
            var thrown = false;
            try
            {
                action();
            }
            catch (T)
            {
                thrown = true;
            }
            Assert.IsTrue(thrown);
        }
