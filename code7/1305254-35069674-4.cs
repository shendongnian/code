        /// <summary>
        /// Setup required before the tests of the fixture will run.
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            ProcessInvoker.InvokeDummyService();
        }
        /// <summary>
        /// Tear down to perform clean when the execution is finished.
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            ProcessInvoker.KillDummyService();
        }
