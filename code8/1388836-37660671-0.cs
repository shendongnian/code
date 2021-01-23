        private void TryTest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                WriteExceptionLogWithScreenshot(e);
                throw;
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
            TryTest(new Action(() =>
            {
                DoSomething();
            }
            ));
        }
        [TestMethod]
        public void TestMethod2()
        {
            TryTest(new Action(() =>
            {
                DoAnotherSomething();
            }
            ));
        }
